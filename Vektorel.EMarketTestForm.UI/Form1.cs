using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vektorel.EMarket.Datacore.Infrastructure;
using MAA.Basecore.Model.Enums;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Datacore.Context;

namespace Vektorel.EMarketTestForm.UI
{
    public partial class Form1 : Form
    {
        private readonly IUserRepository userRepo;


        public Form1(IUserRepository repo)
        {
            InitializeComponent();
            userRepo = repo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = userRepo.Get(x => x.Email == "admin@email.com");

            switch (result.State)
            {
                case BusinessResultType.NotSet:

                    break;
                case BusinessResultType.Success:
                    MessageBox.Show(result.Result.FullName);
                    break;
                case BusinessResultType.Error:
                    MessageBox.Show(result.Message);

                    break;
                case BusinessResultType.Warning:
                    MessageBox.Show(result.Message);

                    break;
                case BusinessResultType.Info:

                    break;
            }

            //EMarketDbContext context = new EMarketDbContext();
            //var x = context.Users.ToList();
            //MessageBox.Show("Test");
        }
    }
}
