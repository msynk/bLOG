using System;
using System.Windows.Forms;
using CookComputing.XmlRpc;

namespace bLOG.Win
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      var proxy = XmlRpcProxyGen.Create<IMetaWeblog>();
      var allPosts = proxy.GetAllPosts("admin", "123");
    }
  }
}
