import React, {Component} from 'react';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            bros: [],
            isLoaded:false
        }
    }
    componentDidMount() {
        fetch('api/Padel/GetBros')
            .then(res => res.json())
            .then(
            (result) => {
                this.setState({
                    isLoaded: true,
                    bros: result.bros
                });
            },
            // Note: it's important to handle errors here
            // instead of a catch() block so that we don't swallow
            // exceptions from actual bugs in components.
            (error) => {
                this.setState({
                    isLoaded: true,
                    error
                });
            }
          )
    }

    render() {
        const { error, isLoaded, bros } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return (
                <ul>
                    {bros.map(bro => (
                        <li key={bro.id}>
                            {bro.name}
                        </li>
                    ))}
                </ul>
            );
        }
    }
}



export default App;