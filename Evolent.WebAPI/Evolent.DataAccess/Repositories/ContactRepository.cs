using Dapper;
using Evolent.DataAccess.Infrastructure;
using Evolent.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.DataAccess.Repositories
{
    public class ContactRepository: IContactRepository
    {
        IConnectionFactory _connectionFactory;

        public ContactRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<ContactDTO> GetContactList()
        {
            List<ContactDTO> lstContactDTO = new List<ContactDTO>();


            try
            {
                var result = _connectionFactory.GetConnection.QueryMultiple(DBConstant.SP_GetContactList, commandType: CommandType.StoredProcedure);
                lstContactDTO = result.Read<ContactDTO>().ToList();
            }
            catch
            {
                throw;
            }
            return lstContactDTO;
        }

        public ResponseDTO  AddContactDetails(ContactDTO contactDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                    var param = new DynamicParameters();
                    param.Add("@paramFirstName", contactDTO.FirstName);
                    param.Add("@paramLastName", contactDTO.LastName);
                    param.Add("@paramEmail", contactDTO.Email == null ? "NA" : contactDTO.Email);
                    param.Add("@paramPhoneNumber", contactDTO.PhoneNumber);
                    var result = SqlMapper.QueryMultiple(_connectionFactory.GetConnection, DBConstant.SP_AddContactDetails, param, commandType: CommandType.StoredProcedure);

                 var ret = result.Read<int>().ToList().Single();
                    responseDTO.IsSuccess = ret > 0 ? true : false;
                    responseDTO.Message = ret > 0 ? "Success" : "Some error occured"; ;
            }
            catch
            {
                responseDTO.IsSuccess = false;
                responseDTO.Message = "Some error occured";
                throw;
            }
           
            return responseDTO;
        }

        public ResponseDTO UpdateContactDetails(ContactDTO contactDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                    var param = new DynamicParameters();
                    param.Add("@paramId", contactDTO.Id);
                    param.Add("@paramFirstName", contactDTO.FirstName);
                    param.Add("@paramLastName", contactDTO.LastName);
                    param.Add("@paramEmail", contactDTO.Email == null ? "NA" : contactDTO.Email);
                    param.Add("@paramPhoneNumber", contactDTO.PhoneNumber);
                    param.Add("@paramIsActive", contactDTO.IsActive);
                    var result = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,DBConstant.SP_UpdateContactDetails, param, commandType: CommandType.StoredProcedure);
                    var ret = result.Read<int>().ToList().Single();
                    responseDTO.IsSuccess = ret > 0 ? true : false;
                    responseDTO.Message = ret > 0 ? "Success" : "Some error occured"; ;
            }
            catch
            {
                responseDTO.IsSuccess = false;
                responseDTO.Message = "Some error occured";
                throw;
            }
          
            return responseDTO;
        }

        public ResponseDTO DeleteContactDetails(ContactDTO contactDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();

            try
            {
                    var param = new DynamicParameters();
                    param.Add("@paramId", contactDTO.Id);

                    var result = SqlMapper.QueryMultiple(_connectionFactory.GetConnection, DBConstant.SP_DeleteContactDetails, param, commandType: CommandType.StoredProcedure);
                    var ret = result.Read<int>().ToList().Single();
                    responseDTO.IsSuccess = ret > 0 ? true : false;
                    responseDTO.Message = ret > 0 ? "Success" : "Some error occured"; ;
            }
            catch
            {
                responseDTO.IsSuccess = false;
                responseDTO.Message = "Some error occured";
                throw;
            }
           
            return responseDTO;
        }
    }
}
