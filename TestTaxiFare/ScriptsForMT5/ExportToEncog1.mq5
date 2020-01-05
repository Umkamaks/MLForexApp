//+------------------------------------------------------------------+
//|                                                ExportToEncog.mq5 |
//|                                      Copyright 2011, Investeo.pl |
//|                                                http:/Investeo.pl |
//+------------------------------------------------------------------+
#property copyright "Copyright 2011, Investeo.pl"
#property link      "http:/Investeo.pl"
#property version   "1.00"
//+------------------------------------------------------------------+
//| Script program start function                                    |
//+------------------------------------------------------------------+

// Export Indicator values for NN training by ENCOG
extern string IndExportFileName = "mt5export.csv";
extern int  trainSize = 1030000;

MqlRates srcArr[];
//double StochKArr[], StochDArr[], WilliamsRArr[];
double MAArr[], RSIArr[], VolumesArr[];

void OnStart()
  {
//---
  // ArraySetAsSeries(srcArr, true);   
  // ArraySetAsSeries(StochKArr, true);   
  // ArraySetAsSeries(StochDArr, true);   
  // ArraySetAsSeries(WilliamsRArr, true);
    ArraySetAsSeries(srcArr, true);   
   ArraySetAsSeries(MAArr, true);   
   ArraySetAsSeries(RSIArr, true);   
   ArraySetAsSeries(VolumesArr, true);     
   int copied = CopyRates(Symbol(), Period(), 26, trainSize, srcArr);
   
   if (copied!=trainSize) { Print("Not enough data for " + Symbol()); return; }
   
  // int hStochastic = iStochastic(Symbol(), Period(), 8, 5, 5, MODE_EMA, STO_LOWHIGH);
  // int hWilliamsR = iWPR(Symbol(), Period(), 21);
  //int hWilliamsR = iVolumes(Symbol(), Period(), VOLUME_TICK);
   
   
   int hRSI = iRSI(Symbol(), Period(), 14, PRICE_CLOSE);
   int hVolumes = iVolumes(Symbol(), Period(), VOLUME_TICK);
   int hMA = iMA(Symbol(), Period(), 14, 0, MODE_EMA, PRICE_MEDIAN);
   
   CopyBuffer(hMA, 0, 26, trainSize, MAArr);
   CopyBuffer(hRSI, 0, 26, trainSize, RSIArr);
   CopyBuffer(hVolumes, 0, 26, trainSize, VolumesArr);
   
  // CopyBuffer(hStochastic, 0, 2, trainSize, StochKArr);
 //  CopyBuffer(hStochastic, 1, 2, trainSize, StochDArr);
 //  CopyBuffer(hWilliamsR, 0, 2, trainSize, WilliamsRArr);
    
   int hFile = FileOpen(IndExportFileName, FILE_CSV | FILE_ANSI | FILE_WRITE | FILE_REWRITE, ",", CP_ACP);
   
   FileWriteString(hFile, "DATE,TIME,CLOSE,MA,RSI,Volumes\n");
   
   Print("Exporting indicator data to " + IndExportFileName+" "+ trainSize + " size!");
   
   for (int i=trainSize-1; i>=1; i--)
      {
         string candleDate = TimeToString(srcArr[i].time, TIME_DATE);
         StringReplace(candleDate,".","");
         string candleTime = TimeToString(srcArr[i].time, TIME_MINUTES);
         StringReplace(candleTime,":","");
       /*  FileWrite(hFile, candleDate, candleTime, DoubleToString(srcArr[i].close), 
                                                  DoubleToString(StochKArr[i], -10),
                                                  DoubleToString(StochDArr[i], -10),
                                                  DoubleToString(WilliamsRArr[i], -10)
                                                  );*/
        FileWrite(hFile, candleDate, candleTime,  DoubleToString(srcArr[i-1].close), 
                                                  DoubleToString(MAArr[i], -10),
                                                  DoubleToString(RSIArr[i], -10),
                                                  DoubleToString(VolumesArr[i], -10)
                                                  );
      }
      
   FileClose(hFile);   
     
   Print("Indicator data exported."); 
  }
//+------------------------------------------------------------------+
