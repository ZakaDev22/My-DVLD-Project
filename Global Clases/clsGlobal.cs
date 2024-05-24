using DVLD_BusinessLayer;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public class clsGlobal
    {
        public static clsUser _User;

        // File System Methods
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }



        // Specify the Registry key and path
        // static variabels for Registry Methods
        private static string keyPath = "HKEY_CURRENT_USER\\SOFTWARE\\DVLD";
        private static string MiniKeyPath = "SOFTWARE\\DVLD";
        private static string valueName = "UserName";
        private static string valueName2 = "Password";

        // Registry Methods
        public static bool RememberUsernameAndPasswordUsingRegistry(string Username, string Password)
        {
            bool IsRemembred = false;


            string KeyValue = Username;

            string KeyValue2 = Password;

            try
            {
                if (KeyValue != "" && KeyValue2 != "")
                {
                    Registry.SetValue(keyPath, valueName, KeyValue, RegistryValueKind.String);
                    Registry.SetValue(keyPath, valueName2, KeyValue2, RegistryValueKind.String);

                    // MessageBox.Show($"Success, UserName {KeyName} And Password Are Successfully Saved In the Registry ✅");


                    IsRemembred = true;
                }
                else
                {
                    // deleting The Current User From Registry If chkRememberMe Is False
                    try
                    {

                        // Open the registry key in read/write mode with explicit registry view
                        using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                        {
                            // deleting User Name From The Registry
                            using (RegistryKey key = baseKey.OpenSubKey(MiniKeyPath, true))
                            {
                                if (key != null)
                                {
                                    // Delete the specified value
                                    key.DeleteValue(valueName);


                                    // Console.WriteLine($"Successfully deleted value '{KeyName}' from registry key '{MiniKeyPath}'");
                                }
                                else
                                {
                                    // Console.WriteLine($"Registry key '{MiniKeyPath}' not found");
                                }
                            }

                            // deleting User Name From The Registry
                            using (RegistryKey key = baseKey.OpenSubKey(MiniKeyPath, true))
                            {
                                if (key != null)
                                {
                                    // Delete the specified value
                                    key.DeleteValue(valueName2);


                                    //  Console.WriteLine($"Successfully deleted value '{KeyName2}' from registry key '{MiniKeyPath}'");
                                }
                                else
                                {
                                    //  Console.WriteLine($"Registry key '{MiniKeyPath}' not found");
                                }
                            }

                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
            }


            return IsRemembred;
        }

        public static bool GetStoredCredentialFromRegistry(ref string UserName, ref string Password)
        {
            bool IsFind = false;

            try
            {
                // Read the value from the Registry
                UserName = Registry.GetValue(keyPath, valueName, null) as string;
                Password = Registry.GetValue(keyPath, valueName2, null) as string;

                if (UserName != null && Password != null)
                {
                    IsFind = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }


            return IsFind;
        }




    }
}
