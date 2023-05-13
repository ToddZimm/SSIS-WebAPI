// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: UnresolvedExecutionErrors
//     Last Modified On: 5/7/2023 3:10:57 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB
{
    #region Using Statments

    using SSIS.DataService.SSISDB.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;

    #endregion Using Statements

    /// <summary>
    /// This file contains the source code for the UnresolvedExecutionErrors routine.
    /// </summary>
    public partial class Service
    {
        #region Build SqlCommand

        private SqlCommand UnresolvedExecutionErrors_BuildCommand(SqlConnection cnn)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.Text,
                CommandText = @"
SELECT ex.execution_id ExecutionId
,pkg.package_id PackageId
,ex.folder_name FolderName
,ex.project_name ProjectName
,ex.package_name PackageName
,ex.status StatusId
,CAST(CASE ex.status
WHEN 3 THEN 'Cancelled'
WHEN 4 THEN 'Failed'
WHEN 6 THEN 'Ended Unexpectedly'
END AS nvarchar(20)) StatusName
,(SELECT TOP(1) em.message
FROM catalog.event_messages em
WHERE message_type IN(120, 130) -- Error, Task Failed
AND em.operation_id = ex.execution_id
order by message_time, event_message_id
) FirstErrorMessage
,ex.created_time CreatedAt
,ex.start_time StartedAt
,ex.end_time EndedAt
,ex.environment_folder_name EnvironmentFolder
,ex.environment_name EnvironmentName
,ex.caller_name CalledBy
,ex.executed_as_name ExecutedAs
,ex.stopped_by_name StoppedBy
,ex.use32bitruntime Use32BitRuntime
,DATEDIFF(SECOND, ex.start_time, ex.end_time) DurationSeconds
,CASE
WHEN DATEDIFF(SECOND, ex.start_time, ex.end_time) < 90
THEN FORMAT(DATEDIFF(MILLISECOND, ex.start_time, ex.end_time) / 1000.0, 'N1') + ' seconds'
WHEN DATEDIFF(SECOND, ex.start_time, ex.end_time) < 3600
THEN FORMAT(DATEDIFF(SECOND, ex.start_time, ex.end_time) / 60.0, 'N1') + ' minutes'
ELSE FORMAT(DATEDIFF(SECOND, ex.start_time, ex.end_time) / 60.0 / 60.0, 'N1') + ' hours'
END AS DurationDisplay
,machine_name ServerName
FROM catalog.executions ex
INNER JOIN (
SELECT folder_name, project_name, package_name, max(execution_id) last_execution_id
FROM catalog.executions
GROUP BY folder_name, project_name, package_name) lastexec on ex.execution_id = lastexec.last_execution_id
INNER JOIN (
SELECT f.name folder_name, pr.name project_name, p.name package_name, p.package_id
FROM catalog.packages p
LEFT JOIN catalog.projects pr on pr.project_id = p.project_id
LEFT JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON pkg.folder_name = ex.folder_name AND pkg.project_name = ex.project_name AND pkg.package_name = ex.package_name
WHERE ex.status IN(3, 4, 6);  --canceled (3), failed (4), ended unexpectedly (6)
SET @Count = @@ROWCOUNT;",
                Connection = cnn
            };

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Count",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int,
                Value = DBNull.Value
            });

            return result;
        }

        #endregion Build SqlCommand

        #region Read Output Parameters And Return Value

        private void UnresolvedExecutionErrors_SetParameters(SqlCommand cmd, UnresolvedExecutionErrorsOutput output)
        {
            if(cmd.Parameters[0].Value != DBNull.Value)
            {
                output.Count = (int?)cmd.Parameters[0].Value;
            }
        }

        #endregion Read Output Parameters And Return Value

        #region Reader To Result Objects
        
        private UnresolvedExecutionErrorsResult UnresolvedExecutionErrors_ResultData(SqlDataReader rdr)
        {
            return new UnresolvedExecutionErrorsResult(
            rdr.GetInt64(0),
            rdr.GetInt64(1),
            rdr.GetString(2),
            rdr.GetString(3),
            rdr.GetString(4),
            rdr.GetInt32(5),
            rdr.IsDBNull(6) ? default : rdr.GetString(6),
            rdr.IsDBNull(7) ? default : rdr.GetString(7),
            rdr.IsDBNull(8) ? default : rdr.GetDateTimeOffset(8),
            rdr.IsDBNull(9) ? default : rdr.GetDateTimeOffset(9),
            rdr.IsDBNull(10) ? default : rdr.GetDateTimeOffset(10),
            rdr.IsDBNull(11) ? default : rdr.GetString(11),
            rdr.IsDBNull(12) ? default : rdr.GetString(12),
            rdr.GetString(13),
            rdr.GetString(14),
            rdr.IsDBNull(15) ? default : rdr.GetString(15),
            rdr.GetBoolean(16),
            rdr.IsDBNull(17) ? default : rdr.GetInt32(17),
            rdr.IsDBNull(18) ? default : rdr.GetString(18),
            rdr.IsDBNull(19) ? default : rdr.GetString(19)
            );
        }
    
        #endregion Reader To Result Objects

        #region Execute Command

        private void UnresolvedExecutionErrors_Execute(SqlCommand cmd, UnresolvedExecutionErrorsOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                output.ResultData = new List<UnresolvedExecutionErrorsResult>();
                while(rdr.Read())
                {
                    output.ResultData.Add(UnresolvedExecutionErrors_ResultData(rdr));
                }
                rdr.Close();
            }

            UnresolvedExecutionErrors_SetParameters(cmd, output);
        }

        #endregion Execute Command

        #region Public Service

        /// <summary>
        /// Returns list of packages where the last execution was not successful.<br/>
        /// DB Routine: dbo.UnresolvedExecutionErrors<br/>
        /// Author: Todd Zimmerman<br/>
        /// </summary>
        /// <returns>Instance of UnresolvedExecutionErrorsOutput</returns>
        public UnresolvedExecutionErrorsOutput UnresolvedExecutionErrors()
        {
            UnresolvedExecutionErrorsOutput output = new UnresolvedExecutionErrorsOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = UnresolvedExecutionErrors_BuildCommand(sqlConnection))
                {
                    cmd.Transaction = sqlTransaction;
                    UnresolvedExecutionErrors_Execute(cmd, output);
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
                    using (SqlCommand cmd = UnresolvedExecutionErrors_BuildCommand(cnn))
                    {
                        cnn.Open();
						UnresolvedExecutionErrors_Execute(cmd, output);
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

