import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/core/data.service';
import { Position } from 'src/app/models/positions/position';

@Component({
  templateUrl: './instrument-detail.component.html',
  styleUrls: ['./instrument-detail.component.css']
})
export class InstrumentDetailComponent implements OnInit, OnDestroy {
  private sub: any;
  public symbol: string;

  public position: Position = new Position();
  
  constructor(
    private data: DataService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.symbol = params['symbol'];
    })

    this.data.getPositionForSymbol(this.symbol)
      .subscribe(success => {
        this.position = this.data.position;
      }, error => {
        this.position = null;
      });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
