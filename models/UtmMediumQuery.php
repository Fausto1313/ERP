<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[UtmMedium]].
 *
 * @see UtmMedium
 */
class UtmMediumQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return UtmMedium[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return UtmMedium|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
