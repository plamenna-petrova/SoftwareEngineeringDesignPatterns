
class Group {
    constructor() {
        this.participants = [];
    }

    get participants() {
        return this._participants;
    }

    set participants(value) {
        this._participants = value;
    }

    doesParticipantExist(participant) {
        return this.participants.includes(participant);
    }
}

module.exports = Group;
