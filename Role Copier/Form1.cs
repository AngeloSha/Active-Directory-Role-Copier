using System;
using System.DirectoryServices;
using System.Windows.Forms;

namespace ADRoleCopier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCopyRoles_Click(object sender, EventArgs e)
        {
            string sourceUserOrGroup = txtSource.Text.Trim();
            string destinationUserOrGroup = txtDestination.Text.Trim();

            if (string.IsNullOrEmpty(sourceUserOrGroup) || string.IsNullOrEmpty(destinationUserOrGroup))
            {
                Log("Source or Destination cannot be empty.");
                return;
            }

            try
            {
                // Automatically determine the AD path
                string ldapPath = GetDefaultNamingContext();

                using (DirectoryEntry entry = new DirectoryEntry(ldapPath))
                {
                    DirectorySearcher searcher = new DirectorySearcher(entry)
                    {
                        Filter = $"(sAMAccountName={sourceUserOrGroup})"
                    };

                    SearchResult sourceResult = searcher.FindOne();
                    if (sourceResult == null)
                    {
                        Log($"Source {sourceUserOrGroup} not found.");
                        return;
                    }

                    DirectoryEntry sourceEntry = sourceResult.GetDirectoryEntry();

                    searcher.Filter = $"(sAMAccountName={destinationUserOrGroup})";
                    SearchResult destinationResult = searcher.FindOne();
                    if (destinationResult == null)
                    {
                        Log($"Destination {destinationUserOrGroup} not found.");
                        return;
                    }

                    DirectoryEntry destinationEntry = destinationResult.GetDirectoryEntry();

                    CopyGroupMembership(sourceEntry, destinationEntry);

                    Log("Group memberships copied successfully.");
                }
            }
            catch (DirectoryServicesCOMException ex)
            {
                Log($"Active Directory error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log($"General error: {ex.Message}");
            }
        }

        private string GetDefaultNamingContext()
        {
            using (DirectoryEntry rootDSE = new DirectoryEntry("LDAP://rootDSE"))
            {
                // Retrieve the default naming context
                return $"LDAP://{rootDSE.Properties["defaultNamingContext"][0]}";
            }
        }

        private void CopyGroupMembership(DirectoryEntry source, DirectoryEntry destination)
        {
            try
            {
                // Iterate over each group the source user is a member of
                foreach (var group in source.Properties["memberOf"])
                {
                    try
                    {
                        using (DirectoryEntry groupEntry = new DirectoryEntry($"LDAP://{group}"))
                        {
                            groupEntry.Properties["member"].Add(destination.Properties["distinguishedName"].Value);
                            groupEntry.CommitChanges();
                            Log($"Added {destination.Properties["sAMAccountName"].Value} to {groupEntry.Properties["sAMAccountName"].Value}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log($"Failed to add {destination.Properties["sAMAccountName"].Value} to group {group}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to copy group memberships: {ex.Message}");
            }
        }

        private void Log(string message)
        {
            lstLog.Items.Add($"{DateTime.Now}: {message}");
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}