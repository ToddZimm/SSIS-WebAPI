// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: PackagesById
//     Last Modified On: 5/3/2023 7:52:59 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB
{
    #nullable enable

    #region Using Statments

    using SSIS.DataService.SSISDB.Models;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;

    #endregion Using Statements

    /// <summary>
    /// This file contains the source code for the PackagesById routine.
    /// </summary>
    public partial class Service
    {
        #region Build SqlCommand

        private SqlCommand PackagesById_BuildCommand(SqlConnection cnn, PackagesByIdInput input)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.Text,
                CommandText = @"
SELECT p.package_id PackageId
,p.name PackageName
,p.description Description
,pr.name ProjectName
,f.name FolderName
,p.package_format_version PackageFormatVersion
,p.validation_status ValidationStatus
,p.last_validation_time LastValidationTime
,p.package_guid PackageGuid
,p.version_guid VersionGuid
,p.version_major VersionMajor
,p.version_minor VersionMinor
,p.version_build VersionBuild
,p.version_comments VersionComments
FROM catalog.packages p
LEFT JOIN catalog.projects pr on pr.project_id = p.project_id
LEFT JOIN catalog.folders f on f.folder_id = pr.folder_id
WHERE p.package_id = @Id;
IF @@ROWCOUNT = 0
BEGIN
SET @ReturnValue=0;
END;
ELSE
BEGIN
SET @ReturnValue = 1;
END;",
                Connection = cnn
            };

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Value = input.Id
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@ReturnValue",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int,
                Value = DBNull.Value
            });

            return result;
        }

        #endregion Build SqlCommand

        #region Read Output Parameters And Return Value

        private void PackagesById_SetParameters(SqlCommand cmd, PackagesByIdOutput output)
        {
            if(cmd.Parameters[1].Value != DBNull.Value)
            {
                output.ReturnValue = (PackagesByIdOutput.Returns)cmd.Parameters[1].Value;
            }
        }

        #endregion Read Output Parameters And Return Value

        #region Reader To Result Objects
        
        private PackagesByIdResult PackagesById_ResultData(SqlDataReader rdr)
        {
            return new PackagesByIdResult(
            rdr.GetInt64(0),
            rdr.GetString(1),
            rdr.IsDBNull(2) ? default : rdr.GetString(2),
            rdr.IsDBNull(3) ? default : rdr.GetString(3),
            rdr.IsDBNull(4) ? default : rdr.GetString(4),
            rdr.GetInt32(5),
            rdr.GetString(6),
            rdr.IsDBNull(7) ? default : rdr.GetDateTimeOffset(7),
            rdr.GetGuid(8),
            rdr.GetGuid(9),
            rdr.GetInt32(10),
            rdr.GetInt32(11),
            rdr.GetInt32(12),
            rdr.IsDBNull(13) ? default : rdr.GetString(13)
            );
        }
    
        #endregion Reader To Result Objects

        #region Execute Command

        private void PackagesById_Execute(SqlCommand cmd, PackagesByIdOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if(rdr.Read())
                {
                    output.ResultData = PackagesById_ResultData(rdr);
                }
                rdr.Close();
            }

            PackagesById_SetParameters(cmd, output);
        }

        #endregion Execute Command

        #region Public Service

        /// <summary>
        /// Returns Project by ID in the SSIS Catalog<br/>
        /// DB Routine: dbo.PackagesById<br/>
        /// Author: Todd Zimmerman<br/>
        /// </summary>
        /// <param name="input">PackagesByIdInput instance.</param>
        /// <returns>Instance of PackagesByIdOutput</returns>
        public PackagesByIdOutput PackagesById(PackagesByIdInput input)
        {
            ValidateInput(input, nameof(PackagesById));
            PackagesByIdOutput output = new PackagesByIdOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = PackagesById_BuildCommand(sqlConnection, input))
                {
                    cmd.Transaction = sqlTransaction;
                    PackagesById_Execute(cmd, output);
                }
                return output;
            }
            for(int idx=0; idx <= retryOptions.RetryIntervals.Count; idx++)
            {
                if (idx > 0)
                {
                    Thread.Sleep(retryOptions.RetryIntervals[idx - 1]);
                }
                try
                {
                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = PackagesById_BuildCommand(cnn, input))
                    {
                        cnn.Open();
						PackagesById_Execute(cmd, output);
                        cnn.Close();
                    }
					break;
                }
                catch(SqlException sqlException)
                {
                    AllowRetryOrThrowError(idx, sqlException);
                }
            }
            return output;
        }

        #endregion

    }
}
