using MediaMonitoringWeb.Data;
using Python.Runtime;

namespace MediaMonitoringWeb.Helpers
{
    public class NltkHelper
    {
        public NltkHelper()
        {
            Setup();
        }

        public string[] TokenizeWord(string kalimat)
        {
            if (string.IsNullOrEmpty(kalimat)) return default;
            try
            {
                using (Py.GIL())
                {
                    dynamic tokenize = Py.Import("nltk.tokenize");
                    string[] tokens = tokenize.word_tokenize(kalimat);
                    return tokens;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }
            
        }
        
        public (List<string> words,List<int> Frequencies) CountingWords(string kalimat)
        {
            var words = new List<string>();
            var freqs = new List<int>();    
            if (string.IsNullOrEmpty(kalimat)) return default;
            try
            {
                using (Py.GIL())
                {
                    dynamic tokenize = Py.Import("nltk.tokenize");
                    dynamic freqdist = Py.Import("nltk.probability");
                    //hapus tanda baca
                    kalimat = kalimat.StripPunctuation().ToLower();
                    string[] tokens = tokenize.word_tokenize(kalimat);
                    dynamic kemunculan = freqdist.FreqDist(tokens);
                    PyTuple[] wordfreqs = kemunculan.most_common();
                    foreach(PyTuple tupple in wordfreqs)
                    {
                        var a = tupple[0];
                        var b = tupple[1];
                        words.Add(a.ToString());
                        freqs.Add(int.Parse( b.ToString()));
                    }
                    return (words,freqs);
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
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
