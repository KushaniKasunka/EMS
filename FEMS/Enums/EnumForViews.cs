using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FEMS.Enums
{
    public class EnumForViews
    {
        public enum TaskState
        {
            [Description("To Do")]
            to_do = 1,
            [Description("Done")]
            done = 2
        }

        public enum Gender
        {
            [Description("Male")]
            male = 1,
            [Description("Female")]
            female = 2
        }

        public enum Designation
        {
            [Description("Project Manager")]
            project_manager=1,
            [Description("Engineering Manager")]
            engineering_manager = 2,
            [Description("Electrical Engineer")]
            elec_engineer = 3,
            [Description("Technical Engineer")]
            tech_engineer = 4,
            [Description("Assistant Electrical Engineer")]
            ass_elec_engineer = 5,
            [Description("Assistant Technical Engineer")]
            ass_tech_engineer = 6,
            [Description("Technician")]
            supervisor = 7,
            [Description("Operator")]
            operators = 8,
            [Description("Labour")]
            labour = 9,
            [Description("Foreman")]
            foreman = 10,
        }

        public enum Month
        {
            [Description("January")]
            january = 1,
            [Description("February")]
            february = 2,
            [Description("March")]
            march = 3,
            [Description("April")]
            april = 4,
            [Description("May")]
            may = 5,
            [Description("June")]
            june = 6,
            [Description("July")]
            july = 7,
            [Description("August")]
            august = 8,
            [Description("September")]
            september = 9,
            [Description("October")]
            october = 10,
            [Description("November")]
            november = 11,
            [Description("December")]
            december = 12
        }

        public enum Approval
        {
            [Description("Pending")]
            Pending = 1,
            [Description("Approved")]
            Approved = 2,
        }
    }
}