//using System;
//using System.Drawing;
//using System.Collections;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data;
//using System.IO;
//using System.Web.Services.Protocols;
//using System.Xml;
//using System.Timers;
//using System.Threading;

////using Microsoft.Web.Services3;
//using Microsoft.Web.Services3.Security;
//using Microsoft.Web.Services3.Security.Tokens;

//namespace FFIECPublicWebServiceSampleClient
//{
//    /// <summary>
//    /// Summary description for Form1.
//    /// </summary>
//    public class Service
//    {
//        public void GetFacsimile(
//            FFIECPublicWebService.RetrievalService proxy,
//            string reportingCycleEndDate, 
//            string retrieveMethod, 
//            FFIECPublicWebService.FinancialInstitutionIDType fiIDType,
//           string UserID,
//           int fiID,
//           string SaveFolderName,
//           FFIECPublicWebService.FacsimileFormat facsimileFormat)
//        {
//            try
//            {
//                FFIECPublicWebService.ReportingDataSeriesName dsName = FFIECPublicWebService.ReportingDataSeriesName.Call;
//                Byte[] facsimileByteArray = proxy.RetrieveFacsimile(dsName, reportingCycleEndDate, fiIDType, fiID, facsimileFormat);
//                string fileDateStamp = reportingCycleEndDate;
//                fileDateStamp = fileDateStamp.Replace("/", "");
//                string idType = retrieveMethod.Replace(" ", "_");
//                string fileName = "FFIEC Call FI " + fiID.ToString() + " (" + fiIDType.ToString() + ") " + fileDateStamp + ".";
//                if (facsimileFormat == FFIECPublicWebService.FacsimileFormat.XBRL)
//                    fileName = fileName + "XBRL.xml";
//                else
//                    fileName = fileName + facsimileFormat;
//                string folderName = SaveFolderName;
//                string filePath = Path.Combine(folderName, fileName);
//                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
//                fileStream.Write(facsimileByteArray, 0, facsimileByteArray.Length);
//                fileStream.Close();
//                Log("OK", "Retrieved facsimile " + filePath);
//            }
//            catch (SoapException ex)
//            {
//                if (ex.Code.Name.Equals("FailedAuthentication"))
//                {
//                    Log("ERROR", "User '" + UserID.Text + "' is NOT authorized to access the FFIEC CDR Public Web Service. Please create a user account using the PDD website.");
//                }
//                else if (ex.Code.Name.Equals("Client.UserQuotaExceeded"))
//                {
//                    int waitTime = Convert.ToInt32(ex.Detail.Attributes["WaitTime"].Value);
//                    Log("OK", String.Format("Web Service quota for user exceeded. Please wait for {0} seconds until the top of the hour for service to renew user quota.", waitTime));
//                }
//                else if (ex.Code.Name.Equals("Server.FacsimileNotFound"))
//                {
//                    Log("ERROR", "Requested facsimile not found in FFICE CDR.");
//                }
//                else
//                {
//                    Log("ERROR", "The Web Service returned an error: " + ex.Message);
//                }
//            }
//        }
//    }
//}
