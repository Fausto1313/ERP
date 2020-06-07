<?php

use yii\helpers\Html;


$this->title = 'Crear Equipo de Venta';
$this->params['breadcrumbs'][] = ['label' => 'Equipo de Venta', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="crm-team-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
