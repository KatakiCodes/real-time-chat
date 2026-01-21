import { NgModule } from "@angular/core";
import { ButtonsModule } from "./buttons/buttons.module";
import { InputsModule } from "./inputs/inputs.module";
import { SideBar } from './side-bar/side-bar';
import { Room } from './room/room';
import { Message } from './message/message';
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";


@NgModule({
    declarations: [
    SideBar,
    Room,
    Message
  ],
    imports: [ButtonsModule, InputsModule, BrowserModule, CommonModule],
    exports: [ButtonsModule,InputsModule,SideBar, Room, CommonModule],
})
export class ComponentsModule {}