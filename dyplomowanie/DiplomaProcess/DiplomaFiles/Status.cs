using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.DiplomaFiles
{
    //definicja statusow w jakich moze znajdowac sie praca
    public enum Status
    {
        NotUploaded,
        Uploaded,
        Modified,
        ToImprove,
        GeneratedAntiplagarismReport,
        AntiplagiarismReportConfirmed,
        AddedOpinion,
        Ready
    }
}
