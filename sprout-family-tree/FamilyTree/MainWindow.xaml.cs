using FamilyTree.ViewModel;
using System.Windows;
using FamilyTree.Class;
using FamilyTree.Domain.Service;

namespace FamilyTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoMapperConfiguration.Configure();
            var presenter = new FamilyTreePresenter(new FileService());
            DataContext = presenter;
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var presenter = (FamilyTreePresenter)DataContext;
                presenter.HandleFilesDrop(files);
            }
        }
    }
}