
class PersonTable extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Peoplelist: []
        }
    }

    
    getPeople = () => {
        fetch("/React/GetPeople").then(response => response.json()).
            then(data => {
                this.setState({ Peoplelist: data})
            })
    }

    sortAtoZ() {
        this.setState(this.state.Peoplelist.sort(function (a, b) {
            return a.name.localeCompare(b.name)
        } ) )
    }
    sortZtoA() {
        this.setState(this.state.Peoplelist.sort(function (a, b) {
            return b.name.localeCompare(a.name)
        }))
    }

    sortUndo() {
        this.getPeople()
    }
    render() {
        const row = this.state.Peoplelist.map((list, i)=> {

            return (
                <tr key={i}>
                    
                     <td >{i + 1}</td>
                     <td>{list.name}</td>
                    <td>{list.phone}</td>
                    <td> <button  > Detail</button> </td>
                </tr>
            )

        })

        return (
            //<div className="PersonTable" > Box </div>
            <div className="PersonTable">
                <div>
                    <div className="ml-2 mb-2 mt-4">
                    <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#createPeopleModal" >Create</button>
                    </div>
                    <h4>PeopleList</h4><hr />
                    <h5>Sort</h5>
                    <button onClick={() => this.sortAtoZ()}>By Name(AtoZ)</button>
                    &nbsp;|&nbsp;
                    <button onClick={() => this.sortZtoA()}>By Name(ZtoA)</button>
                    &nbsp;|&nbsp;
                    <button onClick={() => this.sortUndo()}>None</button>
                    
                </div>
                <div>
                    <table className="table table-active table-hover table-primary">
                        <TableHeaderPeople />
                        <TableRowPeople />
                        {/*<tbody>{ row}</tbody>*/}
                    </table>
                    <CreatePeople/>
                </div>
            </div>

            );
    }
}

//==========================================================================================================
class TableHeaderPeople extends React.Component {
  
    render() {
         return (          
                <thead>
                    <tr>
                        <th >#</th>
                        <th >Name</th>
                        <th >Phone</th>
                        <th >Detail</th>
                        {/*personId, name, phone, cityId, city, speaksLanguages})*/}
                    </tr>
                 </thead>
         
        );
    }
}

//==========================================================================================================
class TableRowPeople extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Peoplelist: []
        }
    }
    componentDidMount() {
        this.getPeople()
    }
    getPeople = () => {
        fetch("/React/GetPeople").then(response => response.json()).
            then(data => {
                this.setState({ Peoplelist: data })
            })
    }
        
    render() {
        const row = this.state.Peoplelist.map((list, i) => {

            return (
                <tr key={i}>

                    <td >{i + 1}</td>
                    <td>{list.name}</td>
                    <td>{list.phone}</td>
                    <td> <button  > Detail</button> </td>
                </tr>
            )

        })

        return (
            
                    
            <tbody>{row}</tbody>
        );
    }
}


//==========================================================================================================

class CreatePeople extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listCountry: [],
            listCity: [],
           // listLanguage:[],
            Name: '',
            Phone: '',
            Country: 0,
            City: 0
            //selectedLan: 0,     
            //Language: []
        };

        this.handleCountryChange = this.handleCountryChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.onchange = this.onchange.bind(this);
       // this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        //this.removeLanguage = this.removeLanguage.bind(this);
        //this.AddLanguage = this.AddLanguage.bind(this);
    }

    handleCountryChange(e) {
       
    
        this.setState({ Country: e.target.value });

        const data = new FormData();   
        data.append('countryId', e.target.value);
        const xhr = new XMLHttpRequest();
        xhr.open('post', '/React/GetCities', true);

        xhr.send(data);

        xhr.onload = function () {
            if (xhr.status === 200) {
               
                this.setState({ listCity: JSON.parse(xhr.response) });
            } else {
                consle.log(xhr.status, ":", xhr.statusText); // 500: Internal server error
            }
        }.bind(this)
    }

    handleCityChange(e) {
     
        this.setState({ City: e.target.value });
    }
    //handleLanguageChange(e) {
 
    //    this.setState({ selectedLan: e.target.value });
    //}

    
    //AddLanguage = (e) => {
    //    debugger;
    //    this.setState({
    //        Language: [...this.state.Language, this.state.selectedLan]
    //    })
    //    const lstLan = this.state.listLanguage.filter(lan => lan.languageId !== this.state.selectedLan)
    //    this.setState({ listLanguage: lstLan })
    //}
    //removeLanguage = (e) => {
    //    const lstLan = this.state.Language.filter(lan => lan.languageId !== e.target.value);
    //    this.setState({ Language: lstLan });


    //    this.setState(prevState => ({
    //        listLanguage: [...prevState.listLanguage, e.target.value]
    //    }))

  
    //};

    handleSubmit = (e) => {
        e.preventDefault();
        
        const data = new FormData();
        data.append('Name', this.state.Name.trim());
        data.append('Phone', this.state.Phone.trim());
        data.append('CityId', this.state.City);
        
        const xhr = new XMLHttpRequest();
        xhr.open('post', '/React/CreatePerson', true);

        xhr.send(data);
        xhr.onload = function () {
            debugger
            if (xhr.status === 200) {             
                this.refreshCreateModal()
                alert(xhr.response);
            } else {
                consle.log(xhr.status, ":", xhr.statusText); // 500: Internal server error
            }
        }.bind(this);
        
    }

    refreshCreateModal() {
     
        this.setState({
            Name: '',
            Phone: '',
            Country: 0,
            City: 0 })
}

    onchange = (e) => {
        this.setState({
                [e.target.name]: e.target.value
        })       
    }
 

    componentDidMount() {
        this.getCountries()
        this.getInitialCites()
        this.getLanguages()
    }
    getCountries = () => {
        fetch("/React/GetCountries").then(response => response.json()).
            then(data => {
                this.setState({ listCountry: data })
            })
    }
    getInitialCites = () => {
        const res = fetch("/React/GetInitialCites").then(response => response.json()).
            then(data => {
                this.setState({ listCity: data })
            })
    }
    getLanguages = () => {
        fetch("/React/GetLanguages").then(response => response.json()).
            then(data => {
                this.setState({ listLanguage: data })
            })
    }
 
  
    render() {
 
        //const row = this.state.Language.map((list, i) => {

        //    return (
        //        <td key={i}>
        //            <button value={list.languageId} onClick={this.removeLanguage} id={list.languageId} >Speak {list.LanguageName} </button>

        //        </td>
        //    )

        //})

        return (

<div className="modal fade" id="createPeopleModal" tabIndex="-1" role="dialog" aria-hidden="true">
  <div className="modal-dialog" role="document">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" >Create People</h5>
        <button type="button" className="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div className="modal-body">
                            <form >
          <div className="form-group">
                                    <label htmlFor="txtname" className="col-form-label">Name:</label>
                                    <input type="text" className="form-control" name="Name" value={this.state.Name} id="txtname" onChange={this.onchange} />
          </div>
          <div className="form-group">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone:</label>
                                    <input type="text" className="form-control" name="Phone" value={this.state.Phone} id="txtPhone" onChange={this.onchange}/>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="txtCountry" >Country:</label>                                       
                                    <select id="txtCountry" value={this.state.Country} onChange={this.handleCountryChange} >
                                            {this.state.listCountry.map((lstCountry,i) => (
                                                <option key={i} value={lstCountry.countryId}>{lstCountry.countryName}</option>
                                                ))}
                                            </select>
                                       
                                    
                                </div>
                            
                                <div className="form-group">
                                    <label htmlFor="txtCity" className="col-form-label">City:</label>
                                    <select id="txtCity" value={this.state.City} onChange={this.handleCityChange} >
                                        {
                                            this.state.listCity.map((lstCity, i) => (
                                            <option key={i} value={lstCity.cityId}>{lstCity.cityName}</option>
                                        ))}
                                    </select>
                                </div>
                                {/*<div >*/}
                                {/*    <table className="table ">*/}
                                {/*        <tbody>{row}</tbody>*/}
                                {/*    </table>*/}
                                      
                                {/*</div>*/}
                                {/*<div className="form-group">*/}
                                {/*    <label htmlFor="txtLanguage" className="col-form-label">Language:</label>*/}
                                {/*    <select id="txtLanguage" value={this.state.selectedLan} onChange={this.handleLanguageChange} >*/}
                                {/*        {*/}
                                {/*            this.state.listLanguage.map((lstLan) => (*/}
                                {/*                <option key={lstLan.languageId} value={lstLan.languageId}>{lstLan.languageName}</option>*/}
                                {/*            ))}*/}
                                {/*    </select>*/}
                                {/*    */}{/*<button id="btnAddLanguage" onClick={this.AddLanguage} type="button"  >Add</button>*/}
                                {/*  </div>*/}


                                <button className="btn btn-primary" type="submit" onClick={this.handleSubmit} >Save</button>

        </form>
      </div>
    
    </div>
  </div>
</div>
            );
    }
}


//==========================================================================================================


    



//==========================================================================================================

ReactDOM.render(<PersonTable />, document.getElementById('content'));
