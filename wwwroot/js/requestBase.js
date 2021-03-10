function getRequest(url) {
    let jwtBearer = localStorage.getItem('bearer');
    return new Promise((resolve, reject) => {
        fetch(url, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + jwtBearer
            }
        }).then(response => {
            if (response.ok) {
                // Save bearer response header.
                var bearer = response.headers.get('Bearer');
                if (bearer != null) {
                    localStorage.setItem('bearer', bearer)
                }
                resolve(response.json());
            }
            else {
                reject();
            }
        });
    });
};

function postRequest(url, bodyObject) {
    let jwtBearer = localStorage.getItem('bearer');
    return new Promise((resolve, reject) => {
        fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + jwtBearer,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bodyObject)
        }).then(response => {
            debugger;
            if (response.ok) {
                // Save bearer response header.
                var bearer = response.headers.get('Bearer');
                if (bearer != null) {
                    localStorage.setItem('bearer', bearer)
                }
                resolve(response.json());
            }
            else {
                reject();
            }
        });
    });
};
