
class Section {

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

class DocumentCreator {
  constructor() {
    this.sections = [];
    this.createSections();
  }

  createSections() {
    throw new Error("Method 'createSections' must be implemented.");
  }
}

class ResumeConcreteCreator extends DocumentCreator {
  createSections() {
    this.sections.push(new SkillsSection(), new EducationSection(), new ExperienceSection());
  }
}

class ReportConcreteCreator extends DocumentCreator {
  createSections() {
    this.sections.push(
      new IntroductionSection(),
      new ResultsSection(),
      new ConclusionSection(),
      new SummarySection(),
      new BibliographySection()
    );
  }
}

const documentCreators = [new ResumeConcreteCreator(), new ReportConcreteCreator()];

documentCreators.forEach((documentCreator) => {
  console.log(`\n-${documentCreator.constructor.name}`);

  documentCreator.sections.forEach((section) => {
    console.log(`${' '.repeat(2)}--${section.constructor.name}`);
  });
});
