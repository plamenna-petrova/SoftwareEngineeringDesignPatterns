
const Request = require("./request");

class CreateProductCommand extends Request {
    constructor(name, price) {
        super();
        this.name = name;
        this.price = price;
    }
}

module.exports = CreateProductCommand;