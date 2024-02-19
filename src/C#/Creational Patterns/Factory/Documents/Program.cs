using System;
using System.Collections.Generic;

namespace Documents
{
    public abstract class Section
    {

    }

    public class SkillsSection : Section
    {

    }

    public class EducationSection : Section
    {

    }

    public class ExperienceSection : Section
    {

    }

    public class IntroductionSection : Section
    {

    }

    public class ResultsSection : Section
    {

    }

    public class ConclusionSection : Section
    {

    }

    public class SummarySection : Section
    {

    }

    public class BibliographySection : Section
    {

    }

    public abstract class DocumentCreator
    {
        public DocumentCreator()
        {
            CreateSections();
        }

        public List<Section> Sections { get; private set; } = new List<Section>();

        public abstract void CreateSections();
    }

    public class ResumeConcreteCreator : DocumentCreator
    {
        public override void CreateSections()
        {
            Sections.Add(new SkillsSection());
            Sections.Add(new EducationSection());
            Sections.Add(new ExperienceSection());
        }
    }

    public class ReportConcreteCreator : DocumentCreator
    {
        public override void CreateSections()
        {
            Sections.Add(new IntroductionSection());
            Sections.Add(new ResultsSection());
            Sections.Add(new ConclusionSection());
            Sections.Add(new SummarySection());
            Sections.Add(new BibliographySection());
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DocumentCreator[] documentCreators = new DocumentCreator[2];

            documentCreators[0] = new ResumeConcreteCreator();
            documentCreators[1] = new ReportConcreteCreator();

            foreach (DocumentCreator documentCreator in documentCreators)
            {
                Console.WriteLine($"\n-{documentCreator.GetType().Name}");

                foreach (Section section in documentCreator.Sections)
                {
                    Console.WriteLine($"{new string(' ', 2)}--{section.GetType().Name}");
                }
            }
        }
    }
}
