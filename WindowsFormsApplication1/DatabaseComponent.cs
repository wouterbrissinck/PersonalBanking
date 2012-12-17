using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BankTest
{
    public partial class DatabaseComponent : Component
    {
        public DatabaseComponent()
        {
            InitializeComponent();
        }

        public DatabaseComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
