﻿using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Helpers
{
    public class ExportHelper
    {
        public IWorkbook CreateTermTextMatrixInXLSX(IEnumerable<TextTermsStat> textTermsStats, IEnumerable<Word> words)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("term-text-matrix");
            IRow headersRow = sheet1.CreateRow(0);
            var headerRowStyle = workbook.CreateCellStyle();
            var headerFont = workbook.CreateFont();
            headerFont.IsBold = true;
            headerRowStyle.SetFont(headerFont);
            headersRow.RowStyle = headerRowStyle;

            var numberHeaderCell = headersRow.CreateCell(0);
            numberHeaderCell.SetCellValue("Id");

            var pubDateHeaderCell = headersRow.CreateCell(1);
            pubDateHeaderCell.SetCellValue("Текст");

            var wordsDict = words.ToDictionary(x => x.Id, x => x.Text);

            int colNumber = 1;
            words = words.OrderBy(x => x.Id);
            foreach(var word in words)
            {
                var wordNameHeader = headersRow.CreateCell(++colNumber);
                wordNameHeader.SetCellValue(word.Text);
            }

            var textRermsStatsArr = textTermsStats.ToArray();
            for (int i = 0; i < textTermsStats.Count(); i++)
            {
                var row = sheet1.CreateRow(i+1);
                var textIdCell = row.CreateCell(0);
                textIdCell.SetCellValue(textRermsStatsArr[i].TextRecord.Id);
                var textTextCell = row.CreateCell(1);
                textTextCell.SetCellValue(textRermsStatsArr[i].TextRecord.Text);

                int columnNumber = 1;
                foreach(var word in words.ToArray())
                {
                    var wordInTextOccuerencesCountCell = row.CreateCell(++columnNumber);
                    wordInTextOccuerencesCountCell.SetCellValue(textRermsStatsArr[i].WordsCount[word.Id]);
                }
            }

            return workbook;
        }
    }
}
