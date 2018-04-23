using System.Windows.Forms;
using System.Data.SqlClient;

namespace SnapServerExamples
{
    public partial class ResultForm : UserControl
    {
        public ResultForm()
        {
            InitializeComponent();
           
            ResultSnapControl2.LoadDocument("Result.snx");
          
        }
        

    }
}
