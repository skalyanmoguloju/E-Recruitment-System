﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data;
using Types;
using BussinessObjectFactory;

namespace DAL
{
    public class PlacementConsultantDB : IPlacementConsultantDB
    {
        List<IPlacementConsultant> placementConsultantList = new List<IPlacementConsultant>();
        IPlacementConsultant placementConsultant=null;

        //INSERTING PLACEMENT CONSULTANT

        public int InsertPlacementConsultant(string placementConsultantName, string password, string placementConsultantDetails)
        {
            int placementConsultantID = 0;

             //ADO.net for inserting the details

            SqlConnection connection = DBUtility.GetConnection();
           

            using (connection)
            {
                SqlCommand command = new SqlCommand();
                SqlDataReader reader;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_InsertPlacementConsultant_667437";

                command.Parameters.AddWithValue("@placementconsultantname", placementConsultantName);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@placementconsultantdetails", placementConsultantDetails);
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    // Console.Write("the placement consultant is registered successfully with id=");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            placementConsultantID = (reader.GetInt32(0));
                        }
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return placementConsultantID;
        }


        //REMOVING PLACEMENT CONSULTANT

        public int DeletePlacementConsultant(int placementConsultantID)
        {                 
            //uses the view generated by selectPlacementConsultant
            int count=0;
            int count1 = 0;
            int result = 0;

            //ADO.NET program for making placementconsultant inactive

              SqlConnection connection = DBUtility.GetConnection();


              using (connection)
              {
                  SqlCommand command = new SqlCommand();
                  command.Connection = connection;
                  command.CommandType = CommandType.StoredProcedure;
                  SqlCommand command1 = new SqlCommand();
                  command1.Connection = connection;
                  command1.CommandType = CommandType.StoredProcedure;
                  command.CommandText = "sp_checkPlacementConsultant_667437";
                  command.Parameters.AddWithValue("@placementconsultantId", placementConsultantID);
                  connection.Open();
                  SqlDataReader reader=command.ExecuteReader();
                  while(reader.Read())
                 count=reader.GetInt32(0);
                 
                  connection.Close();
                  command.CommandText = "sp_checkPlacementConsultant1_667437";
                  //command.Parameters.AddWithValue("@placementconsultantId", placementConsultantID);
                  connection.Open();
                  reader=command.ExecuteReader();
                  while(reader.Read())
                 count1=reader.GetInt32(0);
                  
                  connection.Close();
                  
                  if (count == count1)
                  {
                      command1.CommandText = "sp_deletePlacementConsultant_667437";
                      command1.Parameters.AddWithValue("@placementconsultantId", placementConsultantID);
                      connection.Open();
                      result = command1.ExecuteNonQuery();
                      connection.Close();
                  }
                  //else
                  //{
                  //    command1.CommandText = "sp_deletePlacementConsultantWithRecruitments_667437";
                  //    command1.Parameters.AddWithValue("@placementconsultantId", placementConsultantID);
                  //    connection.Open();
                  //    result = command.ExecuteNonQuery();
                  //    connection.Close();
                  //}
              }
            return result;
        }


        //DISPLAYING PLACEMENT CONSULTANT
        public List<IPlacementConsultant> SelectPlacementConsultant(string placementConsultantName)
        {
            //ADO.NET program for retriving placement consultant
            SqlConnection connection = DBUtility.GetConnection();


            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "sp_SelectPlacementConsultantActive_667437";
            command.Parameters.AddWithValue("@placementconcsultantname", placementConsultantName);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        int PlacementConsultantID = reader.GetInt32(0);
                        string consultantName = reader.GetString(1) ;
                        string placementConsultantDetails = reader.GetString(2);
                        placementConsultant = PlacementConsultantFactory.CreatePlacementConsultant(PlacementConsultantID, consultantName, placementConsultantDetails);
                        placementConsultantList.Add(placementConsultant);
                    }

                    connection.Close();
                
              
                
            
            return placementConsultantList;
        }

        // Load placement consultant list in add recruitment request page
        public Dictionary<int, string> loadPlacementConsultant()
        {
            Dictionary<int, string> net = new Dictionary<int, string>();
            SqlConnection myConnection = DBUtility.GetConnection();

            using (myConnection)
            {
                SqlCommand myCommand = new SqlCommand("sp_getPlacementConsultantDetails", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                myConnection.Open();
                myCommand.ExecuteNonQuery();

                int id = 0;
                string name = "";

                SqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    name = dr.GetString(1);
                    net.Add(id, name);
                }

                myConnection.Close();
                return net;
            }
        }


        //EDITING PLACEMENT CONSULTANT
        public int UpdatePlacementConsultant(int placementConsultantID, string placementConsultantName, string placementConsultantDetails)
        {                                                                       //uses the view generated by selectPlacementConsultant
            int result = 0;
            //ADO.NET program for updating the placementconsultant
            SqlConnection connection = DBUtility.GetConnection();
            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UpdatePlacementConsultant_667437";
                command.Parameters.AddWithValue("@placementconsultantId", placementConsultantID);
                command.Parameters.AddWithValue("@placementconcsultantname", placementConsultantName);
                command.Parameters.AddWithValue("@placementconsultantdetails", placementConsultantDetails);
                connection.Open();
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
          }

        //CREATING EXISTED PLACEMENT CONSULTANT
        public int UpdatePlacementConsultantIfExists(int placementConsultantID)
        {
            //nt placementConsultantID = 0;
            //ADO.net for inserting the details
            SqlConnection connection = DBUtility.GetConnection();

            using (connection)
            {
                SqlCommand command = new SqlCommand();
               
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_updatePlacementConsultantIfExists_667437";
                command.Parameters.AddWithValue("@placementconsultantid", placementConsultantID);
               
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return placementConsultantID;
                
            }
        }


        //DISPLAY INACTIVE PLACEMENT CONSULTANTS
        public List<IPlacementConsultant> SelectPlacementConsultantIfExists(string placementConsultantName)
        {
            //ADO.NET program for retriving placement consultant
            SqlConnection connection = DBUtility.GetConnection();

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader r;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SelectPlacementConsultantIfExists_667437";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@placementconsultantname", placementConsultantName);
                try
                {
                    connection.Open();
                    placementConsultantList.Clear();
                    // Displaying normally placement consultant who is inactive
                    r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int PlacementConsultantID = r.GetInt32(0);
                        string consultantName = r.GetString(1);
                        string placementConsultantDetails = r.GetString(2);
                        placementConsultant = PlacementConsultantFactory.CreatePlacementConsultant(PlacementConsultantID, consultantName, placementConsultantDetails);
                        placementConsultantList.Add(placementConsultant);
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            return placementConsultantList;
        
        }
        public List<IPlacementConsultant> SelectPlacementConsultantIfExistsisActive(string placementConsultantName)
        {
            //ADO.NET program for retriving placement consultant
            SqlConnection connection = DBUtility.GetConnection();

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader r;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SelectPlacementConsultantIfExistsinActive_667437";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@placementconsultantname", placementConsultantName);


                connection.Open();
                placementConsultantList.Clear();
                // Displaying normally placement consultant who is inactive
                r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int PlacementConsultantID = r.GetInt32(0);
                    string consultantName = r.GetString(1);
                    string placementConsultantDetails = r.GetString(2);
                    placementConsultant = PlacementConsultantFactory.CreatePlacementConsultant(PlacementConsultantID, consultantName, placementConsultantDetails);
                    placementConsultantList.Add(placementConsultant);
                }

                connection.Close();
            }
            return placementConsultantList;
        }
    }
}
