using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Business.Interface;
using POS.Repository.UnitOfWork;
using POS.Repository;
using POS.Util.Model;

namespace POS.Business.BusinessComponents
{
    ///Created by Vinod
    ///<summary>
    ///Business logic for POS Terminal
    /// </summary>
    public class TerminalBL
    {
        Context Context;

        public TerminalBL()
        {
            Context = new Context();
        }

        /// <summary>
        /// Get all terminal from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Terminal> GetAll()
        {
            List<tbl_Terminal> Terminal;
            try
            {
                Terminal = Context.Terminal.Get().ToList();
                return Terminal;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Terminal = null;
            }

        }
        /// <summary>
        /// Get one Terminal by location ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<tbl_Terminal> GetByID(string id)
        {
            List<tbl_Terminal> Terminal;
            try
            {
                Terminal = Context.Terminal.Get(e => e.LocationID == id).ToList();
                return Terminal;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                //Location = null;
                // Context = null;
            }

        }



        /// <summary>
        /// Insert Terminal by Terminal model
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public string Insert(tbl_Terminal terminal)
        {
            try
            {
                Context.Terminal.Insert(terminal);
                Context.Terminal.Save();
                return terminal.LocationID + " Inserted Successfully!!";
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return "Error in saving details, Please try again!!";
            }
            finally
            {
                // Context = null;
            }

        }
        /// <summary>
        /// Update terminal by terminal model
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public string Update(tbl_Terminal terminal)
        {
            try
            {
                Context.Terminal.Update(terminal);
                Context.Terminal.Save();
                return terminal.LocationID + " Updated Successfully!!";
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return "Error in saving details, Please try again!!";
            }
            finally
            {
                // Context = null;
            }

        }

        /// <summary>
        /// Delete Terminal by LocationID,TerminalID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool DeleteByID(string LocationID)
        {
            try
            {
                Context.Terminal.Delete(LocationID);
                Context.Terminal.Save();
                return true;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return false;
            }
            finally
            {
                // Context = null;
            }

        }
        /// <summary>
        /// Insert or Update in tbl_terminal table -Vinod 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string InsertOrUpdate(tbl_Terminal terminal)
        {

            List<tbl_Terminal> CurrentTerminal = this.GetparamById(terminal.LocationID.Trim(), terminal.TerminalID.Trim());

            string result = string.Empty;
            if (CurrentTerminal == null || CurrentTerminal.Count == 0)
            {
                return result = this.Insert(terminal);
            }
            else
            {
                // return result = this.Update(location);
            }
            return result;
        }

        public List<tbl_Terminal> GetparamById(string LocationID, string TerminalID)
        {
            List<tbl_Terminal> terminal;
            try
            {
                terminal = Context.Terminal.Get(e => e.LocationID == LocationID.Trim() && e.TerminalID == TerminalID).ToList();
                return terminal;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                // storage = null;
                // Context = null;
            }
        }

        public TerminalModel GetAllTerminal()
        {
            List<Proc_GetAllLTerminal_Result> GetAllTerminal;
            List<tbl_Terminal> Terminal;
            TerminalModel TerminalModel;
            List<tbl_Location> location;
            try
            {
                TerminalModel = new TerminalModel();

                GetAllTerminal = Context.GetAllTerminal().ToList();
                Terminal = this.GetAll();
                location = this.GetAllLocation();

                TerminalModel.GetAllTerminal = GetAllTerminal;
                TerminalModel.Terminal = Terminal;
                TerminalModel.GetAllLocation = location;
                return TerminalModel;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //GetAllTerminal = null;
                //Terminal = null;
                //TerminalModel = null;
            }
        }

        public TerminalModel GetByTerminalId(string LocationID)
        {
            TerminalModel TerminalModel;
            List<Proc_GetMasterTerminal_Result> GetMTerminal;
            List<tbl_Terminal> Terminal;
            try
            {
                TerminalModel = new TerminalModel();
                if (!string.IsNullOrEmpty(LocationID))
                {
                    GetMTerminal = Context.GetMTeminal(LocationID);
                    Terminal = Context.Terminal.Get(e => e.LocationID == LocationID).ToList();

                    TerminalModel.Terminal = Terminal;
                    TerminalModel.GetMTerminal = GetMTerminal;

                    if (GetMTerminal.Count != 0)
                    {
                        TerminalModel.LocationID = GetMTerminal.FirstOrDefault().LocationID;
                        TerminalModel.LocationDesc = GetMTerminal.FirstOrDefault().LocationDesc;
                    }
                    else
                    {
                        TerminalModel.LocationID = null;
                        TerminalModel.LocationDesc = null;
                        TerminalModel.Terminal = null;
                        TerminalModel.GetMTerminal = null;
                    }
                }


                return TerminalModel;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //GetAllTerminal = null;
                //Terminal = null;
                //TerminalModel = null;
            }
        }

        public List<tbl_Location> GetAllLocation()
        {
            List<tbl_Location> Locations;
            try
            {
                Locations = Context.Location.Get().ToList();
                return Locations;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Locations = null;
            }
        }

    }
}
