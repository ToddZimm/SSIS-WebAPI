// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: ExeuctionMessages
//     Last Modified On: 5/13/2023 3:57:13 PM
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
    /// This file contains the source code for the ExeuctionMessages routine.
    /// </summary>
    public partial class Service
    {
        #region Build SqlCommand

        private SqlCommand ExeuctionMessages_BuildCommand(SqlConnection cnn, ExeuctionMessagesInput input)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.Text,
                CommandText = @"
SELECT event_message_id MessageId
,operation_id ExecutionId
,message_time CreatedAt
,CASE
WHEN event_name IN('OnError', 'OnTaskFailed') THEN 'Error'
WHEN event_name IN('OnWarning') THEN 'Warning'
ELSE 'Success'
END Status
,message Message
,message_type MessageTypeId
,CASE message_type
WHEN 10 THEN 'Pre-validate'
WHEN 20 THEN 'Post-validate'
WHEN 30 THEN 'Pre-execute'
WHEN 40 THEN 'Post-execute'
WHEN 50 THEN 'StatusChange'
WHEN 60 THEN 'Progress'
WHEN 70 THEN 'Information'
WHEN 80 THEN 'VariableValueChanged'
WHEN 90 THEN 'Diagnostic'
WHEN 100 THEN 'QueryCancel'
WHEN 110 THEN 'Warning'
WHEN 120 THEN 'Error'
WHEN 130 THEN 'TaskFailed'
WHEN 140 THEN 'DiagnosticEx'
WHEN 200 THEN 'Custom'
WHEN 400 THEN 'NonDiagnostic'
ELSE 'Unknown'
END MessageTypeName
,message_source_type MessageSourceId
,CASE message_source_type
WHEN 10 THEN 'Entry API'
WHEN 20 THEN 'External process'
WHEN 30 THEN 'Package-level object'
WHEN 40 THEN 'Control Flow task'
WHEN 50 THEN 'Control Flow container'
WHEN 60 THEN 'Data Flow task'
ELSE 'Unknown'
END MessageSourceName
,event_name EventName
,subcomponent_name SubComponentName
,execution_path ExecutionPath
FROM catalog.event_messages
WHERE operation_id = @ExecutionId
AND (@BasicLogging = 0 OR message_type > 20)
ORDER BY message_time, event_message_id;
SET @Count = @@ROWCOUNT;",
                Connection = cnn
            };

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@ExecutionId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = input.ExecutionId
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@BasicLogging",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Bit,
                Value = DBNull.Value
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Count",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int,
                Value = DBNull.Value
            });

            if (input.BasicLogging != null)
            {
                result.Parameters["@BasicLogging"].Value = input.BasicLogging;
            }
            return result;
        }

        #endregion Build SqlCommand

        #region Read Output Parameters And Return Value

        private void ExeuctionMessages_SetParameters(SqlCommand cmd, ExeuctionMessagesOutput output)
        {
            if(cmd.Parameters[2].Value != DBNull.Value)
            {
                output.Count = (int?)cmd.Parameters[2].Value;
            }
        }

        #endregion Read Output Parameters And Return Value

        #region Reader To Result Objects
        
        private ExeuctionMessagesResult ExeuctionMessages_ResultData(SqlDataReader rdr)
        {
            return new ExeuctionMessagesResult(
            rdr.IsDBNull(0) ? default : rdr.GetInt64(0),
            rdr.GetInt64(1),
            rdr.GetDateTimeOffset(2),
            rdr.GetString(3),
            rdr.IsDBNull(4) ? default : rdr.GetString(4),
            rdr.GetInt16(5),
            rdr.GetString(6),
            rdr.IsDBNull(7) ? default : rdr.GetInt16(7),
            rdr.GetString(8),
            rdr.IsDBNull(9) ? default : rdr.GetString(9),
            rdr.IsDBNull(10) ? default : rdr.GetString(10),
            rdr.IsDBNull(11) ? default : rdr.GetString(11)
            );
        }
    
        #endregion Reader To Result Objects

        #region Execute Command

        private void ExeuctionMessages_Execute(SqlCommand cmd, ExeuctionMessagesOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                output.ResultData = new List<ExeuctionMessagesResult>();
                while(rdr.Read())
                {
                    output.ResultData.Add(ExeuctionMessages_ResultData(rdr));
                }
                rdr.Close();
            }

            ExeuctionMessages_SetParameters(cmd, output);
        }

        #endregion Execute Command

        #region Public Service

        /// <summary>
        /// Returns messages related to a package execution.<br/>
        /// DB Routine: dbo.ExeuctionMessages<br/>
        /// Author: Todd Zimmerman<br/>
        /// </summary>
        /// <param name="input">ExeuctionMessagesInput instance.</param>
        /// <returns>Instance of ExeuctionMessagesOutput</returns>
        public ExeuctionMessagesOutput ExeuctionMessages(ExeuctionMessagesInput input)
        {
            ValidateInput(input, nameof(ExeuctionMessages));
            ExeuctionMessagesOutput output = new ExeuctionMessagesOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = ExeuctionMessages_BuildCommand(sqlConnection, input))
                {
                    cmd.Transaction = sqlTransaction;
                    ExeuctionMessages_Execute(cmd, output);
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
                    using (SqlCommand cmd = ExeuctionMessages_BuildCommand(cnn, input))
                    {
                        cnn.Open();
						ExeuctionMessages_Execute(cmd, output);
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

