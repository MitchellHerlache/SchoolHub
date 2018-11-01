﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SchoolHub.Infrastructure.Containers;

public class SchoolhubDb
{
    private string connectionString = "server=127.0.0.1; user=team6 ;password=x359; database=team6; port=3306";

    public User GetUserByUsernamePassword(string username, string password)
    {
        string query = "SELECT `User`.`Id`, `Username`, `Email`, `FirstName`, `LastName`, `Role`.`Name` FROM `User` LEFT JOIN `Role` ON `User`.`RoleId` = `Role`.`Id` WHERE `Username` = '" + username + "' AND `Password` = '" + password + "'";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();
            User user = new User();
            while (reader.Read())
            {
                /*
                     * Here, you can iterate through the rows that were returned. To get the first 
                     * value in the the current row, use reader.GetValue(0).ToString(). If it's 
                     * a number, use Convert.ToInt32(reader.GetValue(0)), or whatever other
                     * conversion corresponds to your data type.
                     * To get the 3rd value in the current row, use GetValue(2), and so forth.
                     */
                user.Id = Convert.ToInt32(reader.GetValue(0));
                user.Username = reader.GetValue(1).ToString();
                user.Email = reader.GetValue(2).ToString();
                user.FirstName = reader.GetValue(3).ToString();
                user.LastName = reader.GetValue(4).ToString();
                user.Role = reader.GetValue(5).ToString();
            }
            if(user.Username == null)
            {
                return null;
            }
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // We must assure the connection gets closed, even in the event of an exception.
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        return null;
    }
}
