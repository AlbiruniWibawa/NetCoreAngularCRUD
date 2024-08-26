import { Team } from "./team";

export interface Player {
  id: number,
  nickname: string,
  fullname: string,
  earnings: number,
  isActive: boolean,
  nationality: string,
  teamId: number,
  team?: Team
}
