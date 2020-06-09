<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Usuarios';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-users-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Usuario', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'active',
            'login:ntext',
            'password:ntext',
            'company_id',
            //'partner_id',
            //'create_date',
            //'signature:ntext',
            //'action_id',
            //'share',
            //'create_uid',
            //'write_uid',
            //'write_date',
            //'alias_id',
            //'notification_type:ntext',
            //'out_of_office_message:ntext',
            //'odoobot_state:ntext',
            //'website_id',
            //'sale_team_id',
            //'target_sales_won',
            //'target_sales_done',
            //'target_sales_invoiced',
            //'karma',
            //'rank_id',
            //'next_rank_id',
            //'livechat_username:ntext',
            //'trial532',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
