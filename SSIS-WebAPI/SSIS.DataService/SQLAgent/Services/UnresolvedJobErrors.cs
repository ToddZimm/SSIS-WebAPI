// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: UnresolvedJobErrors
//     Last Modified On: 6/3/2023 7:45:44 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SQLAgent
{
    #region Using Statments

    using SSIS.DataService.SQLAgent.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;

    #endregion Using Statements

    /// <summary>
    /// This file contains the source code for the UnresolvedJobErrors routine.
    /// </summary>
    public partial class Service
    {
        #region Build SqlCommand

        private SqlCommand UnresolvedJobErrors_BuildCommand(SqlConnection cnn)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.Text,
                CommandText = @"
SELECT sjh.instance_id InstanceId
,sjh.instance_id ParentInstanceId
,sjh.job_id JobId
,j.name JobName
,sjh.step_id StepSequenceId
,sjh.step_name StepName
,step.subsystem Subsystem
,step.command Command
,NULL SSISPackageId
,'' SSISPackagePath
,NULL SSISExecutionId
,sjh.message Message
,jt.start_time StartedAt
,jt.end_time EndedAt
,DATEDIFF(SECOND, jt.start_time, jt.end_time) DurationSeconds
,CASE
WHEN DATEDIFF(SECOND, jt.start_time, jt.end_time) < 90
THEN FORMAT(DATEDIFF(SECOND, jt.start_time, jt.end_time), 'N0') + ' seconds'
WHEN DATEDIFF(SECOND, jt.start_time, jt.end_time) < 3600
THEN FORMAT(DATEDIFF(SECOND, jt.start_time, jt.end_time) / 60.0, 'N1') + ' minutes'
ELSE FORMAT(DATEDIFF(SECOND, jt.start_time, jt.end_time) / 60.0 / 60.0, 'N1') + ' hours'
END AS DurationDisplay
,sjh.run_status RunStatusId
,CASE sjh.run_status
WHEN 0 THEN 'Failed'
WHEN 1 THEN 'Succeeded'
WHEN 2 THEN 'Retry'
WHEN 3 THEN 'Canceled'
WHEN 4 THEN 'Step output'
ELSE 'Unknown'
END RunStatusName
,sjh.retries_attempted RetriesAttempted
,sjh.sql_message_id SqlMessageId
,sjh.sql_severity SqlSeverity
,sjh.server Server
,opemail.name OperatorEmailed
,opnet.name OperatorNetSent
,oppage.name OperatorPaged
FROM msdb.dbo.sysjobhistory sjh
INNER JOIN (
SELECT job_id, MAX(instance_id) last_instance
FROM msdb.dbo.sysjobhistory
WHERE step_id = 0  -- job outcomes only
GROUP BY job_id
) last_inst ON last_inst.job_id = sjh.job_id and last_inst.last_instance = sjh.instance_id
OUTER APPLY (
SELECT msdb.dbo.agent_datetime(sjh.run_date, sjh.run_time) AS start_time
,Dateadd(Second, sjh.run_duration % 100 + -- Seconds
(((sjh.run_duration / 100) % 100) * 60) + -- Minutes
((sjh.run_duration / 10000) * 60 * 60), -- Hours
msdb.dbo.agent_datetime(sjh.run_date, sjh.run_time)) AS end_time
) jt
LEFT JOIN msdb.dbo.sysjobs j ON j.job_id = sjh.job_id
LEFT JOIN msdb.dbo.sysjobsteps step ON sjh.job_id = step.job_id and sjh.step_id = step.step_id
LEFT JOIN msdb.dbo.sysoperators opemail ON opemail.id = sjh.operator_id_emailed
LEFT JOIN msdb.dbo.sysoperators opnet ON opnet.id = sjh.operator_id_netsent
LEFT JOIN msdb.dbo.sysoperators oppage ON oppage.id = sjh.operator_id_paged
WHERE sjh.run_status IN (0,3)  -- failed, cancelled
and j.enabled = 1
ORDER BY jt.start_time DESC;
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

        private void UnresolvedJobErrors_SetParameters(SqlCommand cmd, UnresolvedJobErrorsOutput output)
        {
            if(cmd.Parameters[0].Value != DBNull.Value)
            {
                output.Count = (int?)cmd.Parameters[0].Value;
            }
        }

        #endregion Read Output Parameters And Return Value

        #region Reader To Result Objects
        
        private UnresolvedJobErrorsResult UnresolvedJobErrors_ResultData(SqlDataReader rdr)
        {
            return new UnresolvedJobErrorsResult(
            rdr.GetInt32(0),
            rdr.GetInt32(1),
            rdr.GetGuid(2),
            rdr.IsDBNull(3) ? default : rdr.GetString(3),
            rdr.GetInt32(4),
            rdr.GetString(5),
            rdr.IsDBNull(6) ? default : rdr.GetString(6),
            rdr.IsDBNull(7) ? default : rdr.GetString(7),
            rdr.IsDBNull(8) ? default : rdr.GetInt32(8),
            rdr.GetString(9),
            rdr.IsDBNull(10) ? default : rdr.GetInt32(10),
            rdr.IsDBNull(11) ? default : rdr.GetString(11),
            rdr.IsDBNull(12) ? default : rdr.GetDateTime(12),
            rdr.IsDBNull(13) ? default : rdr.GetDateTime(13),
            rdr.IsDBNull(14) ? default : rdr.GetInt32(14),
            rdr.IsDBNull(15) ? default : rdr.GetString(15),
            rdr.GetInt32(16),
            rdr.GetString(17),
            rdr.GetInt32(18),
            rdr.GetInt32(19),
            rdr.GetInt32(20),
            rdr.GetString(21),
            rdr.IsDBNull(22) ? default : rdr.GetString(22),
            rdr.IsDBNull(23) ? default : rdr.GetString(23),
            rdr.IsDBNull(24) ? default : rdr.GetString(24)
            );
        }
    
        #endregion Reader To Result Objects

        #region Execute Command

        private void UnresolvedJobErrors_Execute(SqlCommand cmd, UnresolvedJobErrorsOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                output.ResultData = new List<UnresolvedJobErrorsResult>();
                while(rdr.Read())
                {
                    output.ResultData.Add(UnresolvedJobErrors_ResultData(rdr));
                }
                rdr.Close();
            }

            UnresolvedJobErrors_SetParameters(cmd, output);
        }

        #endregion Execute Command

        #region Public Service

        /// <summary>
        /// Returns list of job where last instance was not successful, ordered by most recent.<br/>
        /// DB Routine: dbo.UnresolvedJobErrors<br/>
        /// Author: Todd Zimmerman<br/>
        /// </summary>
        /// <returns>Instance of UnresolvedJobErrorsOutput</returns>
        public UnresolvedJobErrorsOutput UnresolvedJobErrors()
        {
            UnresolvedJobErrorsOutput output = new UnresolvedJobErrorsOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = UnresolvedJobErrors_BuildCommand(sqlConnection))
                {
                    cmd.Transaction = sqlTransaction;
                    UnresolvedJobErrors_Execute(cmd, output);
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
                    using (SqlCommand cmd = UnresolvedJobErrors_BuildCommand(cnn))
                    {
                        cnn.Open();
						UnresolvedJobErrors_Execute(cmd, output);
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
