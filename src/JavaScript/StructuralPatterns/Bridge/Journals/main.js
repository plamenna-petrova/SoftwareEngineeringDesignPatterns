
class Academy {
    constructor(journal) {
        this.journal = journal;
    }

    addMessage(message) {
        throw new Error('Method not implemented');
    }

    describeEvent(friend, message) {
        throw new Error('Method not implemented');
    }

    poke(targetPerson) {
        throw new Error('Method not implemented');
    }
}

class JediAcademy extends Academy {
    constructor(journal) {
        super(journal);
    }

    addMessage(message) {
        this.journal.addMessage(message);
    }

    describeEvent(friend, message) {
        this.journal.describeEvent(friend, message);
    }

    poke(targetPerson) {
        this.journal.poke(targetPerson);
    }
}

class IJournal {
    addMessage(message) {
        throw new Error('Method not implemented');
    }

    describeEvent(friend, message) {
        throw new Error('Method not implemented');
    }

    poke(targetPerson) {
        throw new Error('Method not implemented');
    }
}

class DailyJournal extends IJournal {
    static community = {};

    constructor(name) {
        super();
        this.name = name;
        DailyJournal.community[name] = this;
        this.pages = '';
    }

    addMessage(message) {
        this.pages += `\n\t\t ${message}`;
        process.stdout.write(`\n\t\t ${'='.repeat(7)} ${this.name}'s' Spacebook ${'='.repeat(7)}`);
        process.stdout.write(`${this.pages}`);
        console.log(`\n\t\t ${'='.repeat(70)}`);
    }

    describeEvent(friend, message) {
        DailyJournal.community[friend].addMessage(message);
    }

    poke(targetPerson) {
        DailyJournal.community[targetPerson].pages += `\n\t\t You have been poked`;
    }
}

class SharedJournal extends IJournal {
    static users = 0;

    constructor(name) {
        super();
        this.name = name;
        SharedJournal.users++;
        this.dailyJournal = new DailyJournal(`${name}'s daily journal`);
    }

    addMessage(message) {
        this.dailyJournal.addMessage(message);
    }

    describeEvent(friend, message) {
        this.dailyJournal.addMessage(`${friend}, ${this.name} said: ${message}`);
    }

    poke(targetPerson) {
        this.dailyJournal.poke(targetPerson);
    }
}

const skywalkerDailyJournal = new DailyJournal('Luke');
skywalkerDailyJournal.addMessage('Hello, Jedi World ');
skywalkerDailyJournal.addMessage('Busy day at training with the green saber today :( ');

const jedisSharedJournal = new SharedJournal('Jedis');
const academy = new JediAcademy(jedisSharedJournal);
academy.poke('Luke');
academy.describeEvent('Luke', 'How is everything going?');
academy.addMessage('Hello there, I have started writing on the shared journal');