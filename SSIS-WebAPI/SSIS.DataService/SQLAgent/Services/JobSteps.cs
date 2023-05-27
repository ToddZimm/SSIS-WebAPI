// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: JobSteps
//     Last Modified On: 5/25/2023 8:34:18 PM
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
    /// This file contains the source code for the JobSteps routine.
    /// </summary>
    public partial class Service
    {
        #region Build SqlCommand

        private SqlCommand JobSteps_BuildCommand(SqlConnection cnn, JobStepsInput input)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.Text,
                CommandText = @"
SELECT step.step_uid StepId
,step.step_name Name
,step.job_id JobId
,job.name JobName
,step.step_id StepSequenceId
,step.subsystem Subsystem
,pkg.package_id SSISPackageId
,pkg.package_path SSISPackagePath
,step.command Command
,step.database_name DatabaseName
,step.database_user_name DatabaseUserName
,prox.name ProxyName
,CASE
WHEN step.last_run_date > 0
THEN CAST(
STUFF(STUFF(CAST(step.last_run_date AS CHAR(8)), 5, 0, '-'), 8, 0, '-') + ' ' +
STUFF(STUFF(RIGHT('000000' + CAST(step.last_run_time AS VARCHAR(6)), 6), 3, 0, ':'), 6, 0, ':')
AS datetime)
ELSE CAST(NULL AS datetime)
END LastRunAt
,CASE step.last_run_outcome
WHEN 0 THEN 'Failed'
WHEN 1 THEN 'Succeeded'
WHEN 2 THEN 'Retry'
WHEN 3 THEN 'Canceled'
ELSE 'Unknown'
END LastOutcome
,CASE step.on_success_action
WHEN 1 THEN 'Quit with success'
WHEN 2 THEN 'Quit with failure'
WHEN 3 THEN 'Go to next step'
WHEN 4 THEN 'Go to step ' + FORMAT(step.on_success_step_id, 'N0')
ELSE 'Unknown'
END OnSuccessAction
,CASE step.on_fail_action
WHEN 1 THEN 'Quit with success'
WHEN 2 THEN 'Quit with failure'
WHEN 3 THEN 'Go to next step'
WHEN 4 THEN 'Go to step ' + FORMAT(step.on_fail_step_id, 'N0')
ELSE 'Unknown'
END OnFailAction
,step.retry_attempts RetryAttempts
,step.retry_interval RetryIntervalMinutes
FROM msdb.dbo.sysjobsteps step
INNER JOIN msdb.dbo.sysjobs job on job.job_id = step.job_id
LEFT JOIN msdb.dbo.sysproxies prox ON step.proxy_id = prox.proxy_id
LEFT JOIN (
SELECT CAST(f.name + '\' + pr.name + '\' + p.name AS nvarchar(500)) package_path, p.package_id
FROM catalog.packages p
JOIN catalog.projects pr on pr.project_id = p.project_id
JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON step.command LIKE '%' + pkg.package_path + '%'
WHERE (@JobId IS NULL OR step.job_id = @JobId)
AND (@PackageId IS NULL OR pkg.package_id = @PackageId)
ORDER BY job.name, step.step_id;
SET @Count = @@ROWCOUNT;",
                Connection = cnn
            };

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@JobId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = DBNull.Value
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@PackageId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Value = DBNull.Value
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Count",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int,
                Value = DBNull.Value
            });

            if (input.JobId != null)
            {
                result.Parameters["@JobId"].Value = input.JobId;
            }
            if (input.PackageId != null)
            {
                result.Parameters["@PackageId"].Value = input.PackageId;
            }
            return result;
        }

        #endregion Build SqlCommand

        #region Read Output Parameters And Return Value

        private void JobSteps_SetParameters(SqlCommand cmd, JobStepsOutput output)
        {
            if(cmd.Parameters[2].Value != DBNull.Value)
            {
                output.Count = (int?)cmd.Parameters[2].Value;
            }
        }

        #endregion Read Output Parameters And Return Value

        #region Reader To Result Objects
        
        private JobStepsResult JobSteps_ResultData(SqlDataReader rdr)
        {
            return new JobStepsResult(
            rdr.IsDBNull(0) ? default : rdr.GetGuid(0),
            rdr.GetString(1),
            rdr.GetGuid(2),
            rdr.GetString(3),
            rdr.GetInt32(4),
            rdr.GetString(5),
            rdr.IsDBNull(6) ? default : rdr.GetInt64(6),
            rdr.IsDBNull(7) ? default : rdr.GetString(7),
            rdr.IsDBNull(8) ? default : rdr.GetString(8),
            rdr.IsDBNull(9) ? default : rdr.GetString(9),
            rdr.IsDBNull(10) ? default : rdr.GetString(10),
            rdr.IsDBNull(11) ? default : rdr.GetString(11),
            rdr.IsDBNull(12) ? default : rdr.GetDateTime(12),
            rdr.GetString(13),
            rdr.IsDBNull(14) ? default : rdr.GetString(14),
            rdr.IsDBNull(15) ? default : rdr.GetString(15),
            rdr.GetInt32(16),
            rdr.GetInt32(17)
            );
        }
    
        #endregion Reader To Result Objects

        #region Execute Command

        private void JobSteps_Execute(SqlCommand cmd, JobStepsOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                output.ResultData = new List<JobStepsResult>();
                while(rdr.Read())
                {
                    output.ResultData.Add(JobSteps_ResultData(rdr));
                }
                rdr.Close();
            }

            JobSteps_SetParameters(cmd, output);
        }

        #endregion Execute Command

        #region Public Service

        /// <summary>
        /// Returns list of SQL Agent job steps.<br/>
        /// DB Routine: dbo.JobSteps<br/>
        /// Author: Todd Zimmerman<br/>
        /// </summary>
        /// <param name="input">JobStepsInput instance.</param>
        /// <returns>Instance of JobStepsOutput</returns>
        public JobStepsOutput JobSteps(JobStepsInput input)
        {
            ValidateInput(input, nameof(JobSteps));
            JobStepsOutput output = new JobStepsOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = JobSteps_BuildCommand(sqlConnection, input))
                {
                    cmd.Transaction = sqlTransaction;
                    JobSteps_Execute(cmd, output);
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
                    using (SqlCommand cmd = JobSteps_BuildCommand(cnn, input))
                    {
                        cnn.Open();
						JobSteps_Execute(cmd, output);
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

