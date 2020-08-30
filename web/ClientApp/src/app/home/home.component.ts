/****This is the UI component for the people list app.****/

import { Component, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs/internal/observable/throwError';
import { catchError } from 'rxjs/operators';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {

  public people: Person[];
  private client: HttpClient;
  private baseUrl: string;
  public isLoading: boolean = true;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.client = http;
    this.baseUrl = baseUrl;
    this.loadList();
    this.isLoading = false;
  }

  public loadList() {
    this.client.get<Person[]>(this.baseUrl).subscribe(result => {
      this.people = result;
    });
  }

  public deletePerson(person: Person) {
    console.log({ "Delete": person })
    const that = this;
    this.client.delete(this.baseUrl + "/" + person.personId)
        .subscribe(() => that.loadList());

  }

  public addPerson(name: string) {
    console.log({ "post": name })
    const that = this;
    this.client.post(this.baseUrl, { name: name })
      .subscribe(()=>that.loadList());
  }
}

interface Person {
  personId: string;
  name: string;
  lastUpdatedOn: Date;
}
