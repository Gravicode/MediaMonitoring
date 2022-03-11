//using Python.Deployment;
using MediaMonitoringWeb.Data;
using Python.Runtime;

namespace MediaMonitoringWeb.Helpers
{
    public class SastrawiHelper
    {
        public SastrawiHelper()
        {
            Setup();
        }

        public string Stemming(string kalimat)
        {
            if (string.IsNullOrEmpty(kalimat)) return string.Empty;
            try
            {
                using (Py.GIL())
                {
                    dynamic stemmerFactory = Py.Import("Sastrawi.Stemmer.StemmerFactory");
                    dynamic factory = stemmerFactory.StemmerFactory();
                    dynamic stemmer = factory.create_stemmer();
                    
                    string output = stemmer.stem(kalimat);
                    return output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return kalimat;
            }
            
        } 
        
        public string RemoveStopWords(string kalimat)
        {
            if (string.IsNullOrEmpty(kalimat)) return string.Empty;
            try
            {
                using (Py.GIL())
                {
                    dynamic stemmerFactory = Py.Import("Sastrawi.StopWordRemover.StopWordRemoverFactory");
                    dynamic factory = stemmerFactory.StopWordRemoverFactory();
                    dynamic stopword = factory.create_stop_word_remover();
                    kalimat = kalimat.StripPunctuation();
                    string stop = stopword.remove(kalimat);
                    return stop;
                    
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return kalimat;
            }
            
        }
        void Setup()
        {
            /*
            await Installer.SetupPython();
            Installer.TryInstallPip();
            Installer.PipInstallModule("PySastrawi");
            PythonEngine.Initialize();
            */
            //Runtime.PythonDLL = AppConstants.PYTHON_DLLPATH;
        }
    }
}
