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
    //private string connectionString = "server=127.0.0.1; user=SWTeam6 ;password=j359; database=SWTeam6; port=3306";

    #region Classes
    public List<Class> GetAllClasses()
    {
        string query = "SELECT `Class`.`Id`, `Number`, `Class`.`Name`, `Description`, `StartDate`, `EndDate`, `TeacherId`, `SchoolId`, CONCAT(`FirstName`,' ',`LastName`) AS `TeacherName`, `School`.`Name` FROM `Class` LEFT JOIN `School` ON `Class`.`SchoolId` = `School`.`Id` LEFT JOIN `User` ON `Class`.`TeacherId` = `User`.`Id`";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();
            List<Class> classes = new List<Class>();
            //Class newClass = new Class();
            while (reader.Read())
            {
                Class newClass = new Class();
                newClass.Id = Convert.ToInt32(reader.GetValue(0));
                newClass.Number = reader.GetValue(1).ToString();
                newClass.Name = reader.GetValue(2).ToString();
                newClass.Description = reader.GetValue(3).ToString();
                newClass.StartDate = reader.GetDateTime(4);
                newClass.EndDate = reader.GetDateTime(5);
                newClass.TeacherId = Convert.ToInt32(reader.GetValue(6));
                newClass.SchoolId = Convert.ToInt32(reader.GetValue(7));
                newClass.TeacherName = reader.GetValue(8).ToString();
                newClass.SchoolName = reader.GetValue(9).ToString();
                classes.Add(newClass);
            }
            return classes;
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

    public List<Class> GetClassesByTeacherId(int teacherId) 
    {
        string query = "SELECT `Class`.`Id`, `Number`, `Class`.`Name`, `Description`, `StartDate`, `EndDate`, `TeacherId`, `SchoolId`, CONCAT(`FirstName`,' ',`LastName`) AS `TeacherName`, `School`.`Name` FROM `Class` LEFT JOIN `School` ON `Class`.`SchoolId` = `School`.`Id` LEFT JOIN `User` ON `Class`.`TeacherId` = `User`.`Id` WHERE `TeacherId` = @teacherId ORDER BY `Number` ASC";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@teacherId", teacherId);
            reader = command.ExecuteReader();
            List<Class> classes = new List<Class>();
            //Class newClass = new Class();
            while (reader.Read())
            {
                Class newClass = new Class();
                newClass.Id = Convert.ToInt32(reader.GetValue(0));
                newClass.Number = reader.GetValue(1).ToString();
                newClass.Name = reader.GetValue(2).ToString();
                newClass.Description = reader.GetValue(3).ToString();
                newClass.StartDate = reader.GetDateTime(4);
                newClass.EndDate = reader.GetDateTime(5);
                newClass.TeacherId = Convert.ToInt32(reader.GetValue(6));
                newClass.SchoolId = Convert.ToInt32(reader.GetValue(7));
                newClass.TeacherName = reader.GetValue(8).ToString();
                newClass.SchoolName = reader.GetValue(9).ToString();
                classes.Add(newClass);
            }
            return classes;
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

    public List<Class> GetClassesByStudentId(int studentId)
    {
        string query = "SELECT `Class`.`Id`, `Number`, `Class`.`Name`, `Description`, `StartDate`, `EndDate`, `TeacherId`, `SchoolId`, CONCAT(`FirstName`,' ',`LastName`) AS `TeacherName`, `School`.`Name` FROM `Class` LEFT JOIN `School` ON `Class`.`SchoolId` = `School`.`Id` LEFT JOIN `User` ON `Class`.`TeacherId` = `User`.`Id` WHERE EXISTS(SELECT * FROM `Enrollment` WHERE `ClassId` = `Class`.`Id` AND `StudentId` = @studentId) ORDER BY `Number` ASC";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@studentId", studentId);
            reader = command.ExecuteReader();
            List<Class> classes = new List<Class>();
            //Class newClass = new Class();
            while (reader.Read())
            {
                Class newClass = new Class();
                newClass.Id = Convert.ToInt32(reader.GetValue(0));
                newClass.Number = reader.GetValue(1).ToString();
                newClass.Name = reader.GetValue(2).ToString();
                newClass.Description = reader.GetValue(3).ToString();
                newClass.StartDate = reader.GetDateTime(4);
                newClass.EndDate = reader.GetDateTime(5);
                newClass.TeacherId = Convert.ToInt32(reader.GetValue(6));
                newClass.SchoolId = Convert.ToInt32(reader.GetValue(7));
                newClass.TeacherName = reader.GetValue(8).ToString();
                newClass.SchoolName = reader.GetValue(9).ToString();
                classes.Add(newClass);
            }
            return classes;
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

    public bool AddClass(Class newClass)
    {
        string query = "INSERT INTO `Class`(`Number`, `Name`, `Description`, `StartDate`, `EndDate`, `TeacherId`, `SchoolId`) VALUES (@classNumber,@className,@classDescription,@startDate,@endDate,@teacherId,@schoolId)";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@classNumber", newClass.Number);
            command.Parameters.AddWithValue("@className", newClass.Name);
            command.Parameters.AddWithValue("@classDescription", newClass.Description);
            command.Parameters.AddWithValue("@startDate", newClass.StartDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@endDate", newClass.EndDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@teacherId", newClass.TeacherId);
            command.Parameters.AddWithValue("@schoolId", newClass.SchoolId);
            command.ExecuteNonQuery();
            return true;
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
        return false;
    }

    public bool EnrollStudentInClass(int studentId, int classId)
    {
        string query = "INSERT INTO `Enrollment`(`ClassId`, `StudentId`) VALUES (@classId,@studentId)";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@classId", classId);
            command.ExecuteNonQuery();
            return true;
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
        return false;
    }

    public bool RemoveStudentFromClass(int studentId, int classId) {
        string query = "DELETE FROM `Enrollment` WHERE `ClassId`=@classId AND `StudentId`=@studentId";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@classId", classId);
            command.ExecuteNonQuery();
            return true;
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
        return false;
    }

    public List<SelectItem> GetAllSchools() {
        string query = "SELECT * FROM `School`";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();
            List<SelectItem> schools = new List<SelectItem>();
            while(reader.Read()) {
                SelectItem newSchool = new SelectItem();
                newSchool.Value = Convert.ToInt32(reader.GetValue(0));
                newSchool.Label = reader.GetValue(1).ToString();
                schools.Add(newSchool);
            }
            return schools;
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
    #endregion

    #region Events

    public bool AddStudentEvent(Event newEvent)
    {
        return false;
    }

    public bool AddClassEvent(Event newEvent)
    {
        return false;
    }

    public List<Event> GetEventsByStudentId(int studentId)
    {
        return new List<Event>();
    }

    public List<Event> GetEventsByClassId(int classId)
    {
        return new List<Event>();
    }

    #endregion

    #region Users
    //Gets corresponding user ID to input username/password combination, returns -1 if no user found.
    public int GetUserIdByUsernamePassword(string username, string password)
    {
        string query = "SELECT `User`.`Id` FROM `User` WHERE `Username` = @username AND `Password` = @password";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            reader = command.ExecuteReader();
            int userId = -1;
            while (reader.Read())
            {
                userId = Convert.ToInt32(reader.GetValue(0));
            }
            return userId;
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
        return -1;
    }

    public User GetUserByUserId(int userId) {
        string query = "SELECT `User`.`Id`, `Username`, `Email`, `FirstName`, `LastName`, `Role`.`Name`, `RoleId` FROM `User` LEFT JOIN `Role` ON `User`.`RoleId` = `Role`.`Id` WHERE `User`.`Id` = @userId";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@userId", userID);
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
                user.RoleId = Convert.ToInt32(reader.GetValue(6));
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
    //Adds new user, returning new userId in string format, or message indicating why user could not be added (use int.TryParse to check return value)
    public string AddUser(User user, string password)
    {
        string query = "INSERT INTO `User`(`Username`, `Password`, `Email`, `FirstName`, `LastName`, `RoleId`) VALUES (@username,@password,@email,@firstName,@lastName,@roleId); SELECT LAST_INSERT_ID();";
        MySqlConnection conn = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            command = new MySqlCommand("SELECT * FROM `User` WHERE `Username` = @username", conn);
            command.Parameters.AddWithValue("@username", user.Username);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                return "A user with the username " + user.Username + " already exists.";
            }
            reader.Close();
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@roleId", user.RoleId);
            reader = command.ExecuteReader();
            int userId = -1;
            while(reader.Read()) {
                userId = Convert.ToInt32(reader.GetValue(0));
            }
            return userId.ToString();
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
        return -1;
    }
    #endregion
