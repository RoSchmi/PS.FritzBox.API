using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.FritzBox.API;

namespace PS.FritzBox.API.CMD
{
    internal class LanConfigSecurityGetUserListHandler : ClientHandler
    {
        LANConfigSecurityClient _client;
        LANConfigSecurityUserList _userList;

        public string UserList = String.Empty;

        public LanConfigSecurityGetUserListHandler(FritzDevice device, Action<string> printOutput, Func<string> getInput, Action wait, Action clearOutput) : base(device, printOutput, getInput, wait, clearOutput)
        {
            this._client = device.GetServiceClient<LANConfigSecurityClient>();
        }

        public override async Task Handle()
        {
            
            try
            {
                await this.GetUserList();       
            }
            catch (Exception ex)
            {
                this.PrintOutputAction(ex.ToString());
                this.WaitAction();            
            }
            
        }

        private async Task GetUserList()
        {
            //this.ClearOutputAction();
            //this.PrintEntry();
            _userList = await this._client.GetUserListAsync();
            UserList = _userList.UserList;
            //this.PrintObject(_userList);
        }   
    }
}

