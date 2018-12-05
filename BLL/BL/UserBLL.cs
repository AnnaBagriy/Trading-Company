using BLL.Interfaces;
using BLL.Services;
using BLL.Strings;
using DTO;
using System;
using System.Collections.Generic;
using TradingCompany.DAL;

namespace BLL
{
    public class UserBLL : IUserBL
    {
        private UserDAL _userDAL;
        private AddressDAL _addressDAL;
        private ActivatingDataDAL _activatingDataDAL;
        private BlockingDataDAL _blockingDataDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
            _addressDAL = new AddressDAL();
            _activatingDataDAL = new ActivatingDataDAL();
            _blockingDataDAL = new BlockingDataDAL();
        }

        public IResponseData<UserDTO> GetUserByID(int id)
        {
            UserDTO user = null;
            string message = "";

            try
            {
                user = _userDAL.GetById(id);
            }
            catch (NullReferenceException)
            {
                message = ErrorMessages.UserNotFound;

                return new ResponseData<UserDTO>(user, message);
            }
            catch (Exception ex)
            {
                message = ErrorMessages.GeneralError + ex.Message;

                return new ResponseData<UserDTO>(user, message);
            }

            return new ResponseData<UserDTO>(user, message);
        }

        public IResponseData<UserDTO> GetUserSignIn(string email, string password)
        {
            UserDTO user = null;
            string message = "";

            try
            {
                user = _userDAL.GetByEmail(email);
            }
            catch (NullReferenceException)
            {
                message = ErrorMessages.UserNotFound;

                return new ResponseData<UserDTO>(user, message);
            }
            catch (Exception ex)
            {
                message = ErrorMessages.GeneralError + ex.Message;

                return new ResponseData<UserDTO>(user, message);
            }

            if (user.Password != password)
            {
                user = null;
                message = ErrorMessages.WrongPassword;

                return new ResponseData<UserDTO>(user, message);
            }
            if (!user.IsAdmin)
            {
                user = null;
                message = ErrorMessages.NoAdminAccessLevel;

                return new ResponseData<UserDTO>(user, message);
            }

            return new ResponseData<UserDTO>(user, message);
        }

        public IResponseData<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> users = null;
            string message = "";

            try
            {
                users = _userDAL.Get();
            }
            catch (NullReferenceException)
            {
                message = ErrorMessages.UserNotFound;

                return new ResponseData<List<UserDTO>>(users, message);
            }
            catch(Exception ex)
            {
                message = ErrorMessages.GeneralError + ex.Message;

                return new ResponseData<List<UserDTO>>(users, message);
            }

            return new ResponseData<List<UserDTO>>(users, message);
        }

        public IResponse UpdateActivatingData(UserDTO user, ActivatingDataDTO activatingData)
        {
            _activatingDataDAL.Add(activatingData);
            _userDAL.Update(user, user.UserId);

            return new Response("");
        }

        public IResponse UpdateUser(UserDTO user)
        {
            _userDAL.Update(user,user.UserId);

            return new Response("");
        }

        public IResponse AddUser(UserDTO user)
        {
            _userDAL.Add(user);

            return new Response("");
        }

        public IResponse UpdateBlockingData(UserDTO user, BlockingDataDTO blockingData)
        {
            _blockingDataDAL.Add(blockingData);
            _userDAL.Update(user, user.UserId);

            return new Response("");
        }

        public IResponseData<List<UserDTO>> GetUsersByPersonalData(string data)
        {
            List<UserDTO> users = new List<UserDTO>();
            UserDTO user = null;
            string message = "";

            var s = data.ToLower();
            
                try
                {
                    user = _userDAL.GetByEmail(s);
                }
                catch (NullReferenceException)
                {
                    message = ErrorMessages.UserNotFound;
                }
                catch (Exception ex)
                {
                    message = ErrorMessages.GeneralError + ex.Message;
                }
                finally
                {
                    if (user != null && !users.Contains(user))
                    {
                        users.Add(user);
                    }

                    user = null;
                }

                try
                {
                    user = _userDAL.GetByNumber(s);
                }
                catch (NullReferenceException)
                {
                    message = ErrorMessages.UserNotFound;
                }
                catch (Exception ex)
                {
                    message = ErrorMessages.GeneralError + ex.Message;
                }
                finally
                {
                    if (user != null && !users.Contains(user))
                    {
                        users.Add(user);
                    }

                    user = null;
                }

                try
                {
                    user = _userDAL.GetByFirstName(s);
                }
                catch (NullReferenceException)
                {
                    message = ErrorMessages.UserNotFound;

                    return new ResponseData<List<UserDTO>>(users, message);
                }
                catch (Exception ex)
                {
                    message = ErrorMessages.GeneralError + ex.Message;

                    return new ResponseData<List<UserDTO>>(users, message);
                }
                finally
                {
                    if (user != null && !users.Contains(user))
                    {
                        users.Add(user);
                    }

                    user = null;
                }

                try
                {
                    user = _userDAL.GetByLastName(s);
                }
                catch (NullReferenceException)
                {
                    message = ErrorMessages.UserNotFound;

                    return new ResponseData<List<UserDTO>>(users, message);
                }
                catch (Exception ex)
                {
                    message = ErrorMessages.GeneralError + ex.Message;

                    return new ResponseData<List<UserDTO>>(users, message);
                }
                finally
                {
                    if (user != null && !users.Contains(user))
                    {
                        users.Add(user);
                    }

                    user = null;
                }
         

            return new ResponseData<List<UserDTO>>(users, message);
        }


    }
}