﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class VacancyRequestDB : IVacancyRequestDB
    {
        public int InsertVacancyRequest(int employeeID, int noOfVacancies)
        {
            int vacancyRequestID = 0;
            //opening of sql connection to the database
            //using two connections for inserting data and getting vacancyRequestID
            SqlConnection conn = DBUtility.GetConnection();
            SqlConnection myConnection = DBUtility.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insertVacancyRequest_667015";
            SqlCommand cmdret = new SqlCommand();
            cmdret.Connection = myConnection;
            cmdret.CommandType = CommandType.StoredProcedure;
            cmdret.CommandText = "sp_vacancyRequestIDGenerate_667015";

            //passing the required parameters
            cmd.Parameters.Add("@employeeid", employeeID);
            cmd.Parameters.Add("@noofpositions", noOfVacancies);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            myConnection.Open();
            SqlDataReader reader = cmdret.ExecuteReader();
            while (reader.Read())
            {
                vacancyRequestID = reader.GetInt32(0);
            }
            myConnection.Close();

            //return of autogenerated vacancyRequestID
            return vacancyRequestID;
        }
    }
}
