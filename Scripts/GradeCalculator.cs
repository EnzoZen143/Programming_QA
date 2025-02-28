using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GradeCalculator : MonoBehaviour
{
    public TMP_InputField writtenWorksInput;
    public TMP_InputField performanceTaskInput;
    public TMP_InputField quarterlyAssessmentInput;
    public TextMeshProUGUI writtenWorksResultText;
    public TextMeshProUGUI performanceTaskResultText;
    public TextMeshProUGUI quarterlyAssessmentResultText;
    public TextMeshProUGUI totalResultText;

    private double writtenWorksWeight = 0.20;
    private double performanceTaskWeight = 0.60;
    private double quarterlyAssessmentWeight = 0.20;

    private double writtenWorksTotal = 15.0;
    private double performanceTaskTotal = 35.0;
    private double quarterlyAssessmentTotal = 50.0;

    public void CalculateGrade()
    {
        double writtenWorksScore, performanceTaskScore, quarterlyAssessmentScore;

        if (double.TryParse(writtenWorksInput.text, out writtenWorksScore) &&
            double.TryParse(performanceTaskInput.text, out performanceTaskScore) &&
            double.TryParse(quarterlyAssessmentInput.text, out quarterlyAssessmentScore))
        {
            double writtenWorksPercentage = (writtenWorksScore / writtenWorksTotal) * 100;
            double performanceTaskPercentage = (performanceTaskScore / performanceTaskTotal) * 100;
            double quarterlyAssessmentPercentage = (quarterlyAssessmentScore / quarterlyAssessmentTotal) * 100;

            double overallGrade = (writtenWorksPercentage * writtenWorksWeight) +
                                  (performanceTaskPercentage * performanceTaskWeight) +
                                  (quarterlyAssessmentPercentage * quarterlyAssessmentWeight);

            writtenWorksResultText.text = "WW 20% = " + writtenWorksPercentage.ToString("F2");
            performanceTaskResultText.text = "PT 60% = " + performanceTaskPercentage.ToString("F2");
            quarterlyAssessmentResultText.text = "QA 20% = " + quarterlyAssessmentPercentage.ToString("F2");
            totalResultText.text = "Total 100% = " + overallGrade.ToString("F2");
        }
        else
        {
            Debug.LogWarning("Invalid input. Please enter numerical values.");
            writtenWorksResultText.text = "WW 20% = ";
            performanceTaskResultText.text = "PT 60% = ";
            quarterlyAssessmentResultText.text = "QA 20% = ";
            totalResultText.text = "Total 100% = ";
        }
    }
}
