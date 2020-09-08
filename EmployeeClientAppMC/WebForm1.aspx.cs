using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeClientApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeClientAppMC.EmployeeServiceProxyMC.IEmployeeService client = new
              EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeServiceClient();
            EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeInfo employee = new EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeInfo();

            if (ddlEmployeeType.SelectedValue == "-1")
            {
                lblMessage.Text = "Please select Employee Type";
            }
            else
            {
                if (((EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue))
                    == EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType.FullTimeEmployee)
                {
                    employee.AnnualSalary = Convert.ToInt32(txtAnnualSalary.Text);
                    employee.Type = EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType.FullTimeEmployee;
                }
                else if (((EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue))
                    == EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType.PartTimeEmployee)
                {
                    employee.HourlyPay = Convert.ToInt32(txtHourlyPay.Text);
                    employee.HoursWorked = Convert.ToInt32(txtHoursWorked.Text);



                    employee.Type = EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType.PartTimeEmployee;
                }

                employee.ID = Convert.ToInt32(txtID.Text);
                employee.Name = txtName.Text;
                employee.Gender = txtGender.Text;
                employee.DOB = Convert.ToDateTime(txtDateOfBirth.Text);

                client.SaveEmployee(employee);
                lblMessage.Text = "Employee saved";
            }
        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {

            EmployeeClientAppMC.EmployeeServiceProxyMC.IEmployeeService client =
                new EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeServiceClient();
            EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeRequest request = new EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeRequest("XYZ120FABC", Convert.ToInt32(txtID.Text));

            EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeInfo employee = client.GetEmployee(request);




            if (employee.Type == EmployeeClientAppMC.EmployeeServiceProxyMC.EmployeeType.FullTimeEmployee)
            {
                txtAnnualSalary.Text = employee.AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text = employee.HourlyPay.ToString();
                txtHoursWorked.Text = employee.HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
            ddlEmployeeType.SelectedValue = ((int)employee.Type).ToString();

            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DOB.ToShortDateString();
            lblMessage.Text = "Employee retrieved";
        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeType.SelectedValue == "-1")
            {
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (ddlEmployeeType.SelectedValue == "1")
            {
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
        }
    }
}