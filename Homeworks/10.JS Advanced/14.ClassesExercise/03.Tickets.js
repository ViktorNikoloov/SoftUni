function ticket(arr, sorting) {
    let inputs = [];
    let allTickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination,
                this.price = Number(price),
                this.status = status
        }
    }

    for (const input of arr) {
        inputs.push(input.split('|'));

    }

    for (const ticket of inputs) {
        let currTicket = new Ticket(ticket[0], ticket[1], ticket[2]);
        allTickets.push(currTicket);
    }

    if (sorting === 'destination') {
        allTickets.sort((a, b) => {
            return a.destination.localeCompare(b.destination);
        })
    } else if (sorting === 'price') {
        allTickets.sort((a, b) => {
            return a.price - b.price;
        })
    } else if (sorting === 'status') {
        allTickets.sort((a, b) => {
            return a.status.localeCompare(b.status);
        })
    }

    return allTickets;
}



console.log(ticket(
    ['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));