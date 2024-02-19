import java.util.ArrayList;
import java.util.List;

abstract class Section {

}

class SkillsSection extends Section {

}

class EducationSection extends Section {

}

class ExperienceSection extends Section {

}

class IntroductionSection extends Section {

}

class ResultsSection extends Section {

}

class ConclusionSection extends Section {

}

class SummarySection extends Section {

}

class BibliographySection extends Section {

}

abstract class DocumentCreator {
    protected List<Section> sections = new ArrayList<>();

    public DocumentCreator() {
        createSections();
    }

    public List<Section> getSections() {
        return sections;
    }

    public abstract void createSections();
}

class ResumeConcreteCreator extends DocumentCreator {
    @Override
    public void createSections() {
        sections.add(new SkillsSection());
        sections.add(new EducationSection());
        sections.add(new ExperienceSection());
    }
}

class ReportConcreteCreator extends DocumentCreator {
    @Override
    public void createSections() {
        sections.add(new IntroductionSection());
        sections.add(new ResultsSection());
        sections.add(new ConclusionSection());
        sections.add(new SummarySection());
        sections.add(new BibliographySection());
    }
}

class Program {
    public static void main(String[] args) {
        DocumentCreator[] documentCreators = new DocumentCreator[2];

        documentCreators[0] = new ResumeConcreteCreator();
        documentCreators[1] = new ReportConcreteCreator();

        for (DocumentCreator documentCreator : documentCreators) {
            System.out.println("\n-" + documentCreator.getClass().getSimpleName());

            for (Section section : documentCreator.getSections()) {
                System.out.println(new String(new char[2]).replace('\0', ' ') + "--" + section.getClass().getSimpleName());
            }
        }
    }
}