<?php

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
    /**
     * @var Section[]
     */
    protected array $sections = [];

    public function __construct() {
        $this->createSections();
    }

    /**
     * @return Section[]
     */
    public function getSections(): array {
        return $this->sections;
    }

    protected abstract function createSections();
}

class ResumeConcreteCreator extends DocumentCreator {
    protected function createSections(): void
    {
        $this->sections[] = new SkillsSection();
        $this->sections[] = new EducationSection();
        $this->sections[] = new ExperienceSection();
    }
}

class ReportConcreteCreator extends DocumentCreator {
    protected function createSections(): void
    {
        $this->sections[] = new IntroductionSection();
        $this->sections[] = new ResultsSection();
        $this->sections[] = new ConclusionSection();
        $this->sections[] = new SummarySection();
        $this->sections[] = new BibliographySection();
    }
}

$documentCreators = [
    new ResumeConcreteCreator(),
    new ReportConcreteCreator(),
];

foreach ($documentCreators as $documentCreator) {
    echo "-" . get_class($documentCreator) . PHP_EOL;

    foreach ($documentCreator->getSections() as $section) {
        echo str_repeat(' ', 2). "--" . get_class($section) . PHP_EOL;
    }
}

