import { useState } from "react";
import axios from "axios";
import { backendUrl } from "utils/utils";

const [responseText, setResponseText] = useState("");

const handlePostRequest = () => {
  // Dados que serão enviados no corpo da requisição POST
  const postData = {
    name: "Exemplo",
    email: "exemplo@email.com",
  };

  axios
    .post(backendUrl, postData)
    .then((response) => {
      setResponseText("Postagem bem-sucedida! Resposta: " + response.data);
    })
    .catch((error) => {
      console.error("Erro ao fazer POST:", error);
      setResponseText("Erro ao fazer a postagem.");
    });
};
