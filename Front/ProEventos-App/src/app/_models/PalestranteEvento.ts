import { Evento } from "./Evento"
import { Palestrante } from "./Palestrante"

export interface PalestranteEvento {
    palestranteid: number
    palestrante: Palestrante
    eventoid: number
    evento: Evento
}