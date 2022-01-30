using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Repository.group;
using Chat_application_with_windows_forms.Repository.reports;
using Chat_application_with_windows_forms.Repository.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Utils
{
    public partial class ReportsForm : Form
    {
        private User loggedUser;
        private ReportsRepo repo;
        private UserRepo userRepo;
        private GroupRepository  groupRepo;
        public ReportsForm(GroupRepository groupRepo,User loggedUser, UserRepo userRepo)
        {
            InitializeComponent();
            this.groupRepo = groupRepo;
            this.loggedUser = loggedUser;
            repo = new ReportsRepo();
            this.userRepo = userRepo;

            fillSentMostMessagesToData();
            fillReceivedMostMessagesFromData();
            fillGroupsMostMessagesSentData();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void fillSentMostMessagesToData()
        {
            Dictionary<long, long> result = repo.sentMostMessagesTo(loggedUser.id);

            Dictionary<string, long> resultInStr = extractDictionaryWithName(result);

            fillDataFromDictionary(resultInStr, dataGridView1);

        }

        private void fillReceivedMostMessagesFromData()
        {
            Dictionary<long, long> result = repo.receivedMostMessagesFrom(loggedUser.id);

            Dictionary<string, long> resultInStr = extractDictionaryWithName(result);

            fillDataFromDictionary(resultInStr, dataGridView2);

        }

        private void fillGroupsMostMessagesSentData()
        {
            Dictionary<long, long> result = repo.groupsWithMostInteraction(loggedUser.id);

            Dictionary<string, long> resultInStr = extractDictionaryWithNameGroup(result);

            fillDataFromDictionary(resultInStr, dataGridView3);

        }

        private void fillDataFromDictionary(Dictionary<string, long> resultInStr, DataGridView dg)
        {
            foreach (KeyValuePair<string, long> k in resultInStr)
            {
               
                string[] row = new string[2];
                row[0] = k.Key;
                row[1] = k.Value.ToString();

                dg.Rows.Add(row);

            }
           
        }

        private Dictionary<string, long > extractDictionaryWithName(Dictionary<long,long> result)
        {
            Dictionary<string, long> resultInString = new Dictionary<string, long>();

            foreach (KeyValuePair<long, long> k in result)
            {
                string username = userRepo.findUserById(k.Key).fullname().Trim();
                resultInString.Add(username, k.Value);
            }

            return resultInString;
        }

        private Dictionary<string, long> extractDictionaryWithNameGroup(Dictionary<long, long> result)
        {
            Dictionary<string, long> resultInString = new Dictionary<string, long>();

            foreach (KeyValuePair<long, long> k in result)
            {
                string group = groupRepo.getGroupById(k.Key,loggedUser).name.Trim();
                resultInString.Add(group, k.Value);
            }

            return resultInString;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
