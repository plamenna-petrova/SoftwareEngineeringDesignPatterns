
class IServant {
    constructor(name, wage, role, productivity, reliability) {
        this.name = name;
        this.wage = wage;
        this.role = role;
        this.productivity = productivity;
        this.reliability = reliability;
    }
}

class Housemaid extends IServant {
    constructor(name, wage, role, productivity, reliability) {
        super(name, wage, role, productivity, reliability);
    }
}

class Cook extends IServant {
    constructor(name, wage, role, productivity, reliability) {
        super(name, wage, role, productivity, reliability);
    }
}

class RoyalCourt {
    constructor() {
        this.servants = [];
    }

    addServant(servant) {
        this.servants.push(servant);
    }

    removeServant(servant) {
        if (servant.reliability < 50) {
            console.log(`${servant.name} will be fired`);
            this.servants = this.servants.filter(s => s !== servant);
        } else {
            console.log(`${servant.name} won't be fired`);
        }
    }

    getServantsWages() {
        return this.servants.reduce((sum, servant) => sum + servant.wage, 0);
    }

    getAverageProductivity() {
        const averageProductivity = this.servants.reduce((sum, servant) => sum + servant.productivity, 0) / this.servants.length;

        if (averageProductivity < 80) {
            console.log("Servants need to put more effort into their tasks");
        } else {
            console.log("Servants have done a great job so far...");
        }

        return averageProductivity;
    }

    getMinimumReliability() {
        const servantWithMinReliability = this.servants.reduce((minReliabilityServant, servant) =>
            (servant.reliability < minReliabilityServant.reliability) ? servant : minReliabilityServant, this.servants[0]);

        return `The servant ${servantWithMinReliability.name} with role -- ${servantWithMinReliability.role} -- has the minimum reliability of ${servantWithMinReliability.Reliability} %`;
    }

    getMaximumReliability() {
        const servantWithMaxReliability = this.servants.reduce((maxReliabilityServant, servant) =>
            (servant.reliability > maxReliabilityServant.reliability) ? servant : maxReliabilityServant, this.servants[0]);

        return `The servant ${servantWithMaxReliability.Name} with role -- ${servantWithMaxReliability.Role} -- has the maximum reliability of ${servantWithMaxReliability.Reliability} %`;
    }

    toBePromoted() {
        let promotionList = '';

        for (const servant of this.servants) {
            if (servant.productivity >= 60) {
                const newWage = servant.wage + 50;
                promotionList += `${servant.name} with role ${servant.role} will be promoted with new wage of ${newWage}\n`;
            }
        }

        return promotionList;
    }
}

// Arrange Servants, Royal Court, and add servants

// housemaids
const firstHouseMaid = new Housemaid("Emma", 150, "cleans the hall", 65, 70);
const secondHouseMaid = new Housemaid("Isabella", 180, "cleans the kitchen", 70, 30);
const thirdHouseMaid = new Housemaid("Gilda", 200, "cleans the guest rooms", 50, 90);
const fourthHouseMaid = new Housemaid("Grace", 260, "cleans the bedrooms", 70, 80);

// cooks
const firstCook = new Cook("Norman", 300, "prepares breakfast Mondays and Fridays", 80, 90);
const secondCook = new Cook("Ray", 280, "prepares dinner Wednesdays and Saturdays", 75, 40);
const thirdCook = new Cook("Don", 250, "prepares desserts", 60, 95);
const fourthCook = new Cook("Phil", 310, "prepares special meals", 90, 90);

const royalCourt = new RoyalCourt();

royalCourt.addServant(firstHouseMaid);
royalCourt.addServant(secondHouseMaid);
royalCourt.addServant(thirdHouseMaid);
royalCourt.addServant(fourthHouseMaid);
royalCourt.addServant(firstCook);
royalCourt.addServant(secondCook);
royalCourt.addServant(thirdCook);
royalCourt.addServant(fourthCook);

royalCourt.removeServant(firstHouseMaid);
royalCourt.removeServant(secondHouseMaid);
royalCourt.removeServant(thirdHouseMaid);
royalCourt.removeServant(fourthHouseMaid);
royalCourt.removeServant(firstCook);
royalCourt.removeServant(secondCook);
royalCourt.removeServant(thirdCook);
royalCourt.removeServant(fourthCook);

console.log(`The sum of servants' wages for all servants is: ${royalCourt.getServantsWages()}`);
console.log(`The average productivity for all servants is: ${royalCourt.getAverageProductivity().toFixed(2)}`);
console.log(`The minimum reliability among all servants is: ${royalCourt.getMinimumReliability()}`);
console.log(`The maximum reliability among all servants is: ${royalCourt.getMaximumReliability()}`);
console.log(`Servants to be promoted:\n${royalCourt.toBePromoted()}`);