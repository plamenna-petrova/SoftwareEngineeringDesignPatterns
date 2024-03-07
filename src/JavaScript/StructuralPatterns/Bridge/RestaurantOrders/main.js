class IRestaurant {
    placeOrder(orderName) {
        throw new Error('Method not implemented');
    }
}

class MiddleClassRestaurant extends IRestaurant {
    placeOrder(orderName) {
        console.log(`Placing order for ${orderName} at ${this.constructor.name}`);
    }
}

class FancyRestaurant extends IRestaurant {
    placeOrder(orderName) {
        console.log(`Placing order for ${orderName} at ${this.constructor.name}`);
    }
}

class Order {
    constructor() {
        this._restaurant = null;
    }

    set restaurant(value) {
        this._restaurant = value;
    }

    sendOrder() {
        throw new Error('Method not implemented');
    }
}

class DiaryFreeOrder extends Order {
    sendOrder() {
        if (this._restaurant) {
            this._restaurant.placeOrder('Dairy-Free Meal');
        } else {
            console.log('No restaurant set for the order.');
        }
    }
}

class GlutenFreeOrder extends Order {
    sendOrder() {
        if (this._restaurant) {
            this._restaurant.placeOrder('Gluten-Free Meal');
        } else {
            console.log('No restaurant set for the order.');
        }
    }
}

let order = new DiaryFreeOrder();
order.restaurant = new MiddleClassRestaurant();
order.sendOrder();

order.restaurant = new FancyRestaurant();
order.sendOrder();

order = new GlutenFreeOrder();
order.restaurant = new MiddleClassRestaurant();
order.sendOrder();

order.restaurant = new FancyRestaurant();
order.sendOrder();