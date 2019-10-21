 Antes de começar a montar o código, fiz uma pequena modelagem (Entidade Relacionamento) para poder entender qual seriam meus objetos. Após a modelagem,
decidi que o padrão de projeto seria o MVC pois me sinto mais confortável em programar. Assim sendo, foi escolhido o tipo do projeto (ASP.NET MVC). 

 Problemas Enfrentados:
   -Como adicionar os produtos no carrinho: A melhor forma seria por cookies, porém, acabei utilizando a sessão por ser mais fácil de manipular. Adicionando
     os um guid da sessão nos carrinhos, dá a possibilidade de trocar de guia ou retornar a navegação sem problemas.
   -Qual das classes criar primeiro: Comecei com o produto pois é nele que boa parte das coisas iriam se basear.
   -Normalização das Tabelas no banco: Infelizmente, a 3º forma normal do banco não foi completamente respeitada, na tabela do Carrinho, aonde o id do Pedido
     não é uma FK.
   -Calcular valor total: para poder calcular o valor total, tive que criar uma variável TempData para guardar o cálculo total de quantidade X valor unitário.(deu bastante dor de cabeça)
   -Tive que usar o guid da sessão na tabela pedidos, para poder relacionar os itens do carrinho com os pedidos.
   -Sem dados do Usuario para começar. Por esse modo, não quis adicionar nada referente ao cliente no pedido e/ou carrinho.
   -Como barrar o usuário de adicionar mais itens no carrinho: O método ideial, é deixar isso totalmente na parte de negócio, porém, uma parcela está na View, o que
    acaba fugindo um pouco do padrão MVC. A mesma coisa se aplica na etapa de finalizar o carrinho, fazendo com que o carrinho totalize um valor de R$ 50,00 ou mais.
   -Utilização dos botões +/- na parte do carrinho. Acredito que com JS teria uma melhor performance e talvez uma apresentação melhor da regra da quantidade dos mesmo itens no carrinho.
    A mesma coisa se aplicaria na etapa de calcular o valor total.
   - Adicionar mais de um produto no carrinho. Ao tentar executar isso, para poder adequar, tive que adicionar uma quantidade considerável de else e if para poder resolver o problema.

    