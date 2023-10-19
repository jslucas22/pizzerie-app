import AsyncStorage from "@react-native-async-storage/async-storage";

import { SETTINGS_COLLECTION } from "../storageConfig";
import { Settings } from "./definitions";

export async function saveSetting(sets: Settings) {
  try {
    const storage = JSON.stringify(sets);

    await AsyncStorage.setItem(`${SETTINGS_COLLECTION}`, storage);
  } catch (err) {
    throw err;
  }
}
