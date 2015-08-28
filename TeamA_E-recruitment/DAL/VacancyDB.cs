﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types;
using BussinessObjectFactory;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class VacancyDB : IVacancyDB
    {
        public List<IVacancy> vacancyList = new List<IVacancy>();
        IVacancy vacancy=null;

        //FUNCTION FOR INSERTING VACANCY
        public int InsertVacancy(int noOfPositions, DateTime requiredByDate, string skills, string domain, int experience, string location, int isApproved, int vacancyRequestID)
        {
            int vacancyID=0;
            SqlConnection conn = DBUtility.GetConnection();
         
            SqlConnection myConnection = DBUtility.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insertVacancy_667015";
            SqlCommand cmdret = new SqlCommand();
            cmdret.Connection = myConnection;
            cmdret.CommandType = CommandType.StoredProcedure;
            cmdret.CommandText = "sp_vacancyIDGenerated_667015";
            int status = 0;
            cmd.Parameters.AddWithValue("@Numofpos", noOfPositions);
            cmd.Parameters.AddWithValue("@RequiredDate", requiredByDate);
            cmd.Parameters.AddWithValue("@Skills", skills);
            cmd.Parameters.AddWithValue("@Domain", domain);
            cmd.Parameters.AddWithValue("@Experience", experience);
            cmd.Parameters.AddWithValue("@Loctaion", location);
            cmd.Parameters.AddWithValue("@IsApproved", isApproved);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@VacancyRequestId", vacancyRequestID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            myConnection.Open();
            SqlDataReader reader = cmdret.ExecuteReader();
            while (reader.Read())
            {
                vacancyID = reader.GetInt32(0);
            }
            myConnection.Close();
            return vacancyID;
        }


        //FUNCTION FOR DELETING VACANCY
        public int DeleteVacany(int vacancyID)  //validation should be done from from the list generated during view for delete
        {                                       //uses the view generated by selectVacancy
            int result = 0;
            //ADO.Net program for deleting a vancancy;
            SqlConnection conn = DBUtility.GetConnection();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_deleteVacany_667015";
            cmd.Parameters.AddWithValue("@vacancyid", vacancyID);
            conn.Open();
            result=cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }


        //FUNCTION FOR UPDATING VACANCY
        public int UpdateVacancy(int vacancyID, int noOfPositions, DateTime requiredByDate, string skills, int experience, string location, int isApproved)     //validation should be done from from the list generated during view for update
        {                                       //uses the view generated by selectVacancy
            int result = 0;
            //ADO.NET program for updating a vacancy
            SqlConnection conn = DBUtility.GetConnection();

            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_updateVacancy_667015";
            
            
           
            //int status = 0;
            cmd.Parameters.AddWithValue("@vacancyId", vacancyID);
            cmd.Parameters.Add("@Numofpos", noOfPositions);
            cmd.Parameters.Add("@RequiredDate", requiredByDate);
            cmd.Parameters.Add("@Skills", skills);
            //cmd.Parameters.Add("@Domain", domain);
            cmd.Parameters.Add("@Experience", experience);
            cmd.Parameters.Add("@Loctaion", location);
            cmd.Parameters.Add("@IsApproved", isApproved);
            //cmd.Parameters.Add("@Status", status);
            conn.Open();
            result=cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }


        //FUNCTION FOR DISPLAYING VACANCY
        public List<IVacancy> SelectVacancy(int employeeID)
        {
            SqlConnection conn = DBUtility.GetConnection();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_selectVacancy_667015";
            cmd.Parameters.AddWithValue("@employeeId", employeeID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int vacancyID = reader.GetInt32(0);
                int noOfPositions = reader.GetInt32(1);
                string skills = reader.GetString(2);
                string domain = reader.GetString(3);
                int experience = reader.GetInt32(4);
                DateTime requiredDate = reader.GetDateTime(5);
                string location = reader.GetString(6);
                int status = reader.GetInt32(7);


                //retirving all vacancies associated to the recruitmentrequestID given
                vacancy = VacancyFactory.CreateVacancy(vacancyID, noOfPositions, skills,domain, experience, requiredDate,location, status);
                vacancyList.Add(vacancy);
            }
            conn.Close();
            
            
            return vacancyList;
        }

        //FUNCTION FOR DISPALYING UNAPPROVED VACANCY
        public List<IVacancy> ViewUnapprovedVacancies(int employeeID)
        {
            vacancyList.Clear();
            //ADO.NET program for displaying unapproved vacancies
            SqlConnection myConnection = DBUtility.GetConnection();//make the connection object
            SqlCommand myCommand = new SqlCommand();//make sqlcommand object
            myCommand.Connection = myConnection;//give connection with the command object
            myCommand.CommandType = CommandType.StoredProcedure;//bind with CommandType
            myCommand.CommandText = "sp_viewUnapprovedVacancies_545444";//bind with CommandText
            myCommand.Parameters.AddWithValue("@employeeId", employeeID);


            myConnection.Open();//Open the connection
            DataTable unapprovedTable = new DataTable();//make DataTable

            SqlDataReader unapprovedDataReader = myCommand.ExecuteReader();//Make DataReader
            unapprovedTable.Load(unapprovedDataReader);//Put all values from DataReader to DataTable

            for (int index = 0; index < unapprovedTable.Rows.Count; index++)//Use for loop to count the rows of the table
            {
                
                int vacancyID = (int)unapprovedTable.Rows[index][0];//get the value from the 1st column of the table
                int noOfPositions = (int)unapprovedTable.Rows[index][1];//get the value from the 2nd column of the table
                string skills = (string)unapprovedTable.Rows[index][2];//get the value from the 3rd column of the table
                string domain = (string)unapprovedTable.Rows[index][3];
                int experience = (int)unapprovedTable.Rows[index][4];//get the value from the 4th column of the table
               
                DateTime requiredDate = (DateTime)unapprovedTable.Rows[index][5];//get the value from the 5th column of the table
                string location = (string)unapprovedTable.Rows[index][6];
                int status = (int)unapprovedTable.Rows[index][7];//get the value from the 6th column of the table

                vacancy = VacancyFactory.CreateVacancy(vacancyID, noOfPositions, skills,domain, experience, requiredDate, location, status);
                vacancyList.Add(vacancy);
            }


            myConnection.Close();//Close the connection

            return vacancyList;//Return the Vacancy type list
        }



        //FUCTION FOR APPROVING VACANCY
        public int ApproveVacancy(int vacancyID)
        {                                                   //uses the view generated by viewUnapprovedVacancies
            int result = 0;
            //ADO.NET program for approving a vacancy Request
            SqlConnection myConnection = DBUtility.GetConnection();//make the connection object
            try
            {

                SqlCommand myCommand = new SqlCommand();//make sqlcommand object
                myCommand.Connection = myConnection;//give connection with the command object
                myCommand.CommandType = CommandType.StoredProcedure;//bind with CommandType
                myCommand.CommandText = "sp_approveVacancy_545444";//bind with CommandText
                myCommand.Parameters.AddWithValue("@vacancyid", vacancyID);//Add the value with the parameter collection

                myConnection.Open();//Open the connection

                myCommand.ExecuteReader();//build sqlDataReader
                return result;//return integer value
            }
            catch (SqlException)
            {
                
            }
            finally
            {
                myConnection.Close();//Close the connection
            }
            return result;//return integer value
        }


        //FUNCTION FOR REJECTING VACANCY
        public int RejectVacancy(int vacancyID)
        {                                                   //uses the view generated by viewUnapprovedVacancies
            int result = 0;
            //ADO.NET program for approving a vacancy Request
            SqlConnection myConnection = DBUtility.GetConnection();//make the connection object
            try
            {

                SqlCommand myCommand = new SqlCommand();//make sqlcommand object
                myCommand.Connection = myConnection;//give connection with the command object
                myCommand.CommandType = CommandType.StoredProcedure;//bind with CommandType
                myCommand.CommandText = "sp_RejectVacancy_545444";//bind with CommandText
                myCommand.Parameters.AddWithValue("@vacancyid", vacancyID);//Add the value with the parameter collection

                myConnection.Open();//Open the connection

                myCommand.ExecuteReader();//build sqlDataReader
                return result;//return the integer value
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();//Close the connection
            }
            return result;//return the integer value
        }
    }
}
