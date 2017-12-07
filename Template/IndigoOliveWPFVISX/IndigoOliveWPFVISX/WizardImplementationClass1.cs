using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;
using System.IO;
using EnvDTE100;
using EnvDTE80;

namespace IndigoOliveWPFVISX {
    public class WizardImplementation : IWizard {
        private IndigoOliveForm inputForm;
        private Dictionary<string, string> _replacementsDictionary = new Dictionary<string, string>();
        private EnvDTE.DTE _dte = null;

        // This method is called before opening any item that   
        // has the OpenInEditor attribute.  
        public void BeforeOpeningFile(ProjectItem projectItem) {
        }

        public void ProjectFinishedGenerating(Project project) {
        }

        // This method is only called for item templates,  
        // not for project templates.  
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem) {
        }

        // This method is called after the project is created.  
        public void RunFinished() {
            string destination = _replacementsDictionary["$destinationdirectory$"];
            string fileName = _replacementsDictionary["$safeprojectname$"] + ".sln";
            _dte.Solution.SaveAs(Path.Combine(destination, fileName));

            if (IndigoOliveForm.mg_eSelectedType == IndigoOliveForm.IndigoOliveSelectedType.EMPTY_PCL) {
                var projectName = $"{_replacementsDictionary["$safeprojectname$"]}";
                var templateName = "EmptyPCLINDIGOWPF";

                AddProject(destination, projectName, templateName);
            }
        }

        private void AddProject(string destination, string projectName, string templateName) {
            string projectPath = Path.Combine(destination, projectName);
            string templatePath = ((Solution4)_dte.Solution).GetProjectTemplate(templateName, "CSharp");

            _dte.Solution.AddFromTemplate(templatePath, projectPath, projectName, false);
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams) {
            /** Store the reference to the environment for later use **/
            _dte = automationObject as EnvDTE.DTE;
            _replacementsDictionary = replacementsDictionary;

            try {
                // Display a form to the user. The form collects   
                // input for the custom message.  
                inputForm = new IndigoOliveForm();
                inputForm.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        // This method is only called for item templates,  
        // not for project templates.  
        public bool ShouldAddProjectItem(string filePath) {
            return true;
        }
    }
}
